using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("EmployeeCode", Name = "UQ__Employee__1F642548E04601C3", IsUnique = true)]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string EmployeeCode { get; set; } = null!;

    [StringLength(90)]
    public string Name { get; set; } = null!;

    [StringLength(90)]
    public string LastName { get; set; } = null!;

    [StringLength(10)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(150)]
    public string EmailAddress { get; set; } = null!;

    [StringLength(20)]
    public string Gender { get; set; } = null!;

    [StringLength(150)]
    public string Country { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    [StringLength(20)]
    public string MartialStatus { get; set; } = null!;

    [StringLength(150)]
    public string City { get; set; } = null!;

    [StringLength(10)]
    public string PostalCode { get; set; } = null!;

    [StringLength(100)]
    public string Province { get; set; } = null!;

    [StringLength(150)]
    public string Address { get; set; } = null!;

    [StringLength(10)]
    public string AptUnit { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("JobPositionID")]
    public int JobPositionId { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<CustomerDeliveryAddress> CustomerDeliveryAddresses { get; set; } = new List<CustomerDeliveryAddress>();

    [InverseProperty("Employee")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [ForeignKey("JobPositionId")]
    [InverseProperty("Employees")]
    public virtual JobPosition JobPosition { get; set; } = null!;

    [InverseProperty("ApplyToEmployee")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("Employees")]
    public virtual Status Status { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
