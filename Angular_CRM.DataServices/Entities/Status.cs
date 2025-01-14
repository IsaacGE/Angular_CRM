using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRM.DataServices.Entities;

[Table("Status")]
[Index("Title", Name = "UQ__Status__2CB664DC734D0F7A", IsUnique = true)]
public partial class Status
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<CustomerDeliveryAddress> CustomerDeliveryAddresses { get; set; } = new List<CustomerDeliveryAddress>();

    [InverseProperty("Status")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Status")]
    public virtual ICollection<DeliveryType> DeliveryTypes { get; set; } = new List<DeliveryType>();

    [InverseProperty("Status")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Status")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Status")]
    public virtual ICollection<JobPosition> JobPositions { get; set; } = new List<JobPosition>();

    [InverseProperty("Status")]
    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();

    [InverseProperty("Status")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    [InverseProperty("Status")]
    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    [InverseProperty("Status")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("Status")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("Status")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    [InverseProperty("Status")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
