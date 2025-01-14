using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Folio", Name = "UQ__Sales__BAB84EF766C26F23", IsUnique = true)]
public partial class Sale
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Folio { get; set; } = null!;

    [Column("MovementID")]
    public int MovementId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("ApplyToEmployeeID")]
    public int ApplyToEmployeeId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("GlobalOfferID")]
    public int? GlobalOfferId { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    public double Tax { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalTax { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalShipping { get; set; }

    [Column("DiscountPCT")]
    public double DiscountPct { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalDiscount { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("SourceID")]
    public int? SourceId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("DeliveryAddressID")]
    public int? DeliveryAddressId { get; set; }

    [Column("DeliveryDateEST_Start", TypeName = "datetime")]
    public DateTime DeliveryDateEstStart { get; set; }

    [Column("DeliveryDateEST_End", TypeName = "datetime")]
    public DateTime DeliveryDateEstEnd { get; set; }

    [StringLength(255)]
    public string? Notes { get; set; }

    [ForeignKey("ApplyToEmployeeId")]
    [InverseProperty("Sales")]
    public virtual Employee ApplyToEmployee { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("Sales")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Sales")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("DeliveryAddressId")]
    [InverseProperty("Sales")]
    public virtual CustomerDeliveryAddress? DeliveryAddress { get; set; }

    [ForeignKey("GlobalOfferId")]
    [InverseProperty("Sales")]
    public virtual Offer? GlobalOffer { get; set; }

    [InverseProperty("Source")]
    public virtual ICollection<Sale> InverseSource { get; set; } = new List<Sale>();

    [ForeignKey("MovementId")]
    [InverseProperty("Sales")]
    public virtual Movement Movement { get; set; } = null!;

    [InverseProperty("Sale")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    [ForeignKey("SourceId")]
    [InverseProperty("InverseSource")]
    public virtual Sale? Source { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Sales")]
    public virtual Status Status { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Sales")]
    public virtual User User { get; set; } = null!;
}
