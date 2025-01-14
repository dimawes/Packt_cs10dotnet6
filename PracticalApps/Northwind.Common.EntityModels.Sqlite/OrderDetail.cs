﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace West.Shared
{
    [Table("Order Details")]
    [Index("OrderId", Name = "OrderId")]
    [Index("OrderId", Name = "OrdersOrder_Details")]
    [Index("ProductId", Name = "ProductId")]
    [Index("ProductId", Name = "ProductsOrder_Details")]
    public partial class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public short Quantity { get; set; }
        [Column(TypeName = "real")]
        public double Discount { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; } = null!;
    }
}
