using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Sku", Name = "UQ__Products__CA1ECF0D6F0EF113", IsUnique = true)]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Column("SKU")]
    [StringLength(35)]
    public string Sku { get; set; } = null!;

    [StringLength(150)]
    public string Title { get; set; } = null!;

    [StringLength(450)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public double Stock { get; set; }

    public double MinimumStock { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    [ForeignKey("StatusId")]
    [InverseProperty("Products")]
    public virtual Status Status { get; set; } = null!;
}
