using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("Title", Name = "UQ__Categori__2CB664DCBFA73821", IsUnique = true)]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("CategoryTypeID")]
    public int CategoryTypeId { get; set; }

    [ForeignKey("CategoryTypeId")]
    [InverseProperty("Categories")]
    public virtual CategoryType CategoryType { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
