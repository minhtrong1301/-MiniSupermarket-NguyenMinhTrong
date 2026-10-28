
namespace MiniSupermarket.API.DTOs
{
    // Chứa dữ liệu phân trang trả về cho WinForms.
    public class PagedResult<T>
    {
        // Trang hiện tại.
        public int CurrentPage { get; set; }

        // Số sản phẩm tối đa trong một trang.
        public int PageSize { get; set; }

        // Tổng số sản phẩm thỏa mãn điều kiện tìm kiếm.
        public int TotalItems { get; set; }

        // Tổng số trang.
        public int TotalPages { get; set; }

        // Danh sách dữ liệu của trang hiện tại.
        public List<T> Items { get; set; } = new List<T>();
    }
}
