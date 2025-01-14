using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

public partial class CustomerDeliveryAddress
{
    [Key]
    public int Id { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

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

    [StringLength(255)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerDeliveryAddresses")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("CustomerDeliveryAddresses")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("DeliveryAddress")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("StatusId")]
    [InverseProperty("CustomerDeliveryAddresses")]
    public virtual Status Status { get; set; } = null!;
}
