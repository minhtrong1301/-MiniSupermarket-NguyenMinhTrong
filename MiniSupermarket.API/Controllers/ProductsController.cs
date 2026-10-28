using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using MiniSupermarket.API.DTOs;
namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. READ: Lấy toàn bộ danh sách sản phẩm từ SQL Server
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Products.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // 2. READ: Lấy chi tiết 1 sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm trong CSDL!" });
            }
            return Ok(product);
        }


        // 3. READ: Tìm sản phẩm theo mã vạch để sử dụng tại màn hình POS
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Vui lòng nhập mã vạch!" });
            }

            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Barcode == barcode);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm có mã vạch này!"
                });
            }

            return Ok(product);
        }


        // 4. CREATE: Thêm mới sản phẩm vào Database
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product newProd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(newProd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newProd.ProductId }, newProd);
        }

        // 5. UPDATE: Cập nhật sản phẩm vào Database
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updateProd)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần sửa!" });
            }

            prod.Barcode = updateProd.Barcode;
            prod.ProductName = updateProd.ProductName;
            prod.Price = updateProd.Price;
            prod.StockQuantity = updateProd.StockQuantity;
            prod.CategoryId = updateProd.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa sản phẩm khỏi Database
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 7. READ: Lấy danh sách sản phẩm có tìm kiếm và phân trang
        // GET: /api/products/paged?keyword=banh&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] string? keyword = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5,
            [FromQuery] int? categoryId = null)
        {
            // Kiểm tra số trang hợp lệ.
            if (pageNumber < 1)
            {
                return BadRequest(new
                {
                    message = "Số trang phải lớn hơn hoặc bằng 1."
                });
            }

            // Giới hạn kích thước trang để tránh tải quá nhiều dữ liệu.
            if (pageSize < 1 || pageSize > 50)
            {
                return BadRequest(new
                {
                    message = "Số sản phẩm mỗi trang phải từ 1 đến 50."
                });
            }

            // Truy vấn sản phẩm và lấy thông tin danh mục liên quan.
            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            // Nếu có từ khóa, tìm theo tên sản phẩm hoặc mã vạch.
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim();

                query = query.Where(p =>
                    p.ProductName.Contains(search) ||
                    p.Barcode.Contains(search));
            }
            // Nếu có chọn danh mục, chỉ lấy sản phẩm thuộc danh mục đó.
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }
            // Đếm tổng số sản phẩm sau khi áp dụng điều kiện tìm kiếm.
            int totalItems = await query.CountAsync();

            // Tính tổng số trang.
            int totalPages = (int)Math.Ceiling(
                totalItems / (double)pageSize);

            // Chỉ lấy dữ liệu thuộc trang được yêu cầu.
            var items = await query
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null
                        ? p.Category.CategoryName
                        : string.Empty
                })
                .ToListAsync();

            // Đóng gói dữ liệu và thông tin phân trang.
            var result = new PagedResult<ProductItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return Ok(result);
        }

    }
}