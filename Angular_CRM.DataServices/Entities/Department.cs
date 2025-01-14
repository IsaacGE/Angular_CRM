using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class Department
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

    [Column("StatusID")]
    public int StatusId { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<JobPosition> JobPositions { get; set; } = new List<JobPosition>();

    [ForeignKey("StatusId")]
    [InverseProperty("Departments")]
    public virtual Status Status { get; set; } = null!;
}
