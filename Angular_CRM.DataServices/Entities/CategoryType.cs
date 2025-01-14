using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Title", Name = "UQ__Category__2CB664DC348337A4", IsUnique = true)]
public partial class CategoryType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("CategoryType")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
