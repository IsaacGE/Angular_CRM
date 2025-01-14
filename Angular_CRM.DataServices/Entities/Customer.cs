using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Index("CustomerCode", Name = "UQ__Customer__066785213B25B1FC", IsUnique = true)]
public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string CustomerCode { get; set; } = null!;

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

    public DateOnly? BirthDate { get; set; }

    [StringLength(20)]
    public string? MartialStatus { get; set; }

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

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<CustomerDeliveryAddress> CustomerDeliveryAddresses { get; set; } = new List<CustomerDeliveryAddress>();

    [ForeignKey("EmployeeId")]
    [InverseProperty("Customers")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("Customers")]
    public virtual Status Status { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
