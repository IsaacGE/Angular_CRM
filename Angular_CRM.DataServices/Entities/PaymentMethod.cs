using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Title", Name = "UQ__PaymentM__2CB664DC65761072", IsUnique = true)]
public partial class PaymentMethod
{
    [Key]
    public int Id { get; set; }

    [StringLength(45)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    [ForeignKey("StatusId")]
    [InverseProperty("PaymentMethods")]
    public virtual Status Status { get; set; } = null!;
}
