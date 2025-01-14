using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Title", Name = "UQ__Delivery__2CB664DCC374EB4E", IsUnique = true)]
public partial class DeliveryType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [InverseProperty("DeliveryType")]
    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    [ForeignKey("StatusId")]
    [InverseProperty("DeliveryTypes")]
    public virtual Status Status { get; set; } = null!;
}
