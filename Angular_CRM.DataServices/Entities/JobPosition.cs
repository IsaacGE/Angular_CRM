using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class JobPosition
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("JobPositions")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("JobPosition")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("StatusId")]
    [InverseProperty("JobPositions")]
    public virtual Status Status { get; set; } = null!;
}
