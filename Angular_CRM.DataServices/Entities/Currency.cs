using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Table("Currency")]
[Index("Code", Name = "UQ__Currency__A25C5AA70A7E298A", IsUnique = true)]
public partial class Currency
{
    [Key]
    public int Id { get; set; }

    [StringLength(5)]
    public string Code { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [InverseProperty("Currency")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
