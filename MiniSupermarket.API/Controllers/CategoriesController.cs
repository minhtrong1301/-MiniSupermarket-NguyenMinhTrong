using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        // Tiêm DbContext thông qua Constructor Injection
        public CategoriesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. READ: Lấy toàn bộ danh mục từ SQL Server
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // 2. READ: Lấy chi tiết 1 danh mục theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng trong CSDL!" });
            }
            return Ok(category);
        }

        // 3. SEARCH: Tìm kiếm qua Query String trên SQL Server
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }
            // EF Core dịch biểu thức LINQ thành câu lệnh SQL LIKE tương ứng
            var result = await _context.Categories
                .Where(c => c.CategoryName.Contains(keyword))
                .ToListAsync();
            return Ok(result);
        }

        // 4. CREATE: Thêm mới nhóm hàng vào Database
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(newCat);
            await _context.SaveChangesAsync(); // Lưu thay đổi vào SQL Server

            return CreatedAtAction(nameof(GetById), new { id = newCat.CategoryId }, newCat);
        }

        // 5. UPDATE: Cập nhật nhóm hàng vào Database
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category updateCat)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần sửa!" });
            }

            cat.CategoryName = updateCat.CategoryName;
            cat.Description = updateCat.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa nhóm hàng khỏi Database
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần xóa!" });
            }

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 1.1 READ: Lấy danh mục có phân trang
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5,
            [FromQuery] string? keyword = null)
        {
            // Kiểm tra số trang và số lượng bản ghi mỗi trang
            if (pageNumber < 1)
            {
                return BadRequest(new
                {
                    message = "Số trang phải lớn hơn hoặc bằng 1!"
                });
            }

            if (pageSize < 1 || pageSize > 100)
            {
                return BadRequest(new
                {
                    message = "Số danh mục mỗi trang phải từ 1 đến 100!"
                });
            }

            // Truy vấn danh mục từ SQL Server, không theo dõi để tối ưu đọc dữ liệu
            var query = _context.Categories.AsNoTracking();

            // Nếu có từ khóa thì lọc theo tên danh mục
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(c => c.CategoryName.Contains(keyword));
            }

            // Đếm tổng số danh mục sau khi áp dụng tìm kiếm
            var totalItems = await query.CountAsync();

            // Tính tổng số trang
            var totalPages = (int)Math.Ceiling(
                totalItems / (double)pageSize
            );

            // Lấy danh mục của trang hiện tại
            var items = await query
                .OrderBy(c => c.CategoryId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Trả về dữ liệu và thông tin phân trang
            return Ok(new
            {
                currentPage = pageNumber,
                pageSize = pageSize,
                totalItems = totalItems,
                totalPages = totalPages,
                items = items
            });
        }

    }
}
