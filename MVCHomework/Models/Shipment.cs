using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHomework.Models;

public class Shipment
{
    public int Id { get; set; }
    public DateTime ShipDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(Sale))]
    public int SaleId { get; set; }
    public Sale Sale { get; set; }
}