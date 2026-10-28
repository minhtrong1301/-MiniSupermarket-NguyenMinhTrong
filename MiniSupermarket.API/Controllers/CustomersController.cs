using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. GET: /api/customers - Lấy toàn bộ danh sách khách hàng
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return Ok(customers);
        }


        // GET: /api/customers/paged?pageNumber=1&pageSize=5&keyword=Nguyen
        // Phân trang và tìm kiếm khách hàng theo tên hoặc số điện thoại
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5,
            [FromQuery] string? keyword = null)
        {
            // Kiểm tra tham số phân trang
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest(new
                {
                    message = "Số trang và kích thước trang phải lớn hơn 0!"
                });
            }

            // Giới hạn số bản ghi mỗi trang
            if (pageSize > 100)
            {
                return BadRequest(new
                {
                    message = "Kích thước trang không được vượt quá 100!"
                });
            }

            // Tạo truy vấn ban đầu
            var query = _context.Customers.AsNoTracking();

            // Nếu có từ khóa, tìm theo tên hoặc số điện thoại
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(c =>
                    (c.CustomerName != null &&
                     c.CustomerName.Contains(keyword)) ||
                    (c.PhoneNumber != null &&
                     c.PhoneNumber.Contains(keyword)));
            }

            // Sắp xếp điểm thưởng giảm dần
            query = query
                .OrderByDescending(c => c.RewardPoints)
                .ThenBy(c => c.CustomerId);

            // Đếm tổng số khách hàng sau khi lọc
            int totalItems = await query.CountAsync();

            // Tính tổng số trang
            int totalPages = (int)Math.Ceiling(
                totalItems / (double)pageSize);

            // Nếu không có dữ liệu thì vẫn trả về trang 1
            if (totalPages == 0)
            {
                pageNumber = 1;
            }
            // Nếu trang yêu cầu vượt quá tổng số trang
            else if (pageNumber > totalPages)
            {
                pageNumber = totalPages;
            }

            // Lấy dữ liệu của trang hiện tại
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new
                {
                    c.CustomerId,
                    c.CustomerName,
                    c.PhoneNumber,
                    c.Address,
                    c.RewardPoints,
                    c.MembershipRank
                })
                .ToListAsync();

            // Trả về dữ liệu cùng thông tin phân trang
            return Ok(new
            {
                currentPage = pageNumber,
                pageSize,
                totalItems,
                totalPages,
                items
            });
        }



        // 2. GET: /api/customers/{id} - Lấy chi tiết khách hàng theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng trong hệ thống!" });
            }
            return Ok(customer);
        }

        // 3. GET: /api/customers/search?keyword=... - Tìm kiếm theo tên hoặc số điện thoại

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập số điện thoại!"
                });
            }

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.PhoneNumber == phone);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            return Ok(customer);
        }

        // 4. POST: /api/customers - Thêm mới khách hàng
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerId }, newCustomer);
        }

        // 5. PUT: /api/customers/{id} - Cập nhật thông tin khách hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer updateCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng cần cập nhật!" });
            }

            customer.CustomerName = updateCustomer.CustomerName;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.Address = updateCustomer.Address;
            customer.RewardPoints = updateCustomer.RewardPoints;
            customer.MembershipRank = updateCustomer.MembershipRank;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: /api/customers/{id} - Xóa khách hàng
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng cần xóa!" });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}