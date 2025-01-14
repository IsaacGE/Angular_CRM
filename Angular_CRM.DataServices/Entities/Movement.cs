using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Title", Name = "UQ__Movement__2CB664DCEF7E37A6", IsUnique = true)]
public partial class Movement
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

    [InverseProperty("Movement")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("Movements")]
    public virtual Status Status { get; set; } = null!;
}
