using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        // Tên tài khoản thu ngân thực hiện giao dịch
        [Required]
        [StringLength(100)]
        public string CashierUsername { get; set; } = string.Empty;

        // Khách vãng lai có thể không có CustomerId
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }

        // Lưu số điện thoại tại thời điểm bán hàng
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string? CustomerPhone { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CashReceived { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ChangeAmount { get; set; }

        // Danh sách sản phẩm thuộc hóa đơn
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}