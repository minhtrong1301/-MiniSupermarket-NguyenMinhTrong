using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

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

        // 3. SEARCH: Tìm kiếm sản phẩm theo tên hoặc mã vạch
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            var result = await _context.Products
                .Where(p => p.ProductName.Contains(keyword) || p.Barcode.Contains(keyword))
                .ToListAsync();
            return Ok(result);
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
    }
}