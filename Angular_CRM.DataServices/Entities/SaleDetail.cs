using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class SaleDetail
{
    [Key]
    public int Id { get; set; }

    public double Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(255)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateAdded { get; set; }

    [Column("DiscountPCT")]
    public double DiscountPct { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalDiscount { get; set; }

    [Column("SaleID")]
    public int SaleId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column("OfferDetailID")]
    public int? OfferDetailId { get; set; }

    [ForeignKey("OfferDetailId")]
    [InverseProperty("SaleDetails")]
    public virtual OfferDetail? OfferDetail { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SaleDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SaleId")]
    [InverseProperty("SaleDetails")]
    public virtual Sale Sale { get; set; } = null!;
}
