using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHomework.Models;

public class Cart
{
    public int Id { get; set; }
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}