using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LastAccess { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Users")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Users")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual UserRole Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("Users")]
    public virtual Status Status { get; set; } = null!;
}
