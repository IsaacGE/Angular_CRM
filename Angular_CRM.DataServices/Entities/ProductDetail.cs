using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class ProductDetail
{
    [Key]
    public int Id { get; set; }

    [StringLength(350)]
    public string ImageUrl { get; set; } = null!;

    [StringLength(155)]
    public string? Description { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductDetails")]
    public virtual Product Product { get; set; } = null!;
}
