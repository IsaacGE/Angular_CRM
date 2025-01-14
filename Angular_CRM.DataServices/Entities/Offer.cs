using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Folio", Name = "UQ__Offers__BAB84EF7F99EE454", IsUnique = true)]
public partial class Offer
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string Folio { get; set; } = null!;

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("DiscountPCT")]
    public double? DiscountPct { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Offers")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("GlobalOffer")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("Offers")]
    public virtual Status Status { get; set; } = null!;
}
