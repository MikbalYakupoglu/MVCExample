using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHomework.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    [ForeignKey(nameof(Address))]
    public int AddressId { get; set; }
    public Address Address { get; set; }

    [ForeignKey(nameof(CustomerType))]
    public int CustomerTypeId { get; set; }
    public CustomerType CustomerType { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Payment))]
    public int PaymentId { get; set; }
    public Payment Payment { get; set; }
}