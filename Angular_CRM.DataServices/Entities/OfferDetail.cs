using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class OfferDetail
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OfferedPrice { get; set; }

    [Column("DiscountPCT")]
    public double? DiscountPct { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public double? QuantityMin { get; set; }

    [Column("PaymentMethodID")]
    public int? PaymentMethodId { get; set; }

    [Column("DeliveryTypeID")]
    public int? DeliveryTypeId { get; set; }

    [ForeignKey("DeliveryTypeId")]
    [InverseProperty("OfferDetails")]
    public virtual DeliveryType? DeliveryType { get; set; }

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("OfferDetails")]
    public virtual PaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OfferDetails")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("OfferDetail")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
