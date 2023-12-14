using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHomework.Models;

public class Payment
{
    public int Id { get; set; }
    public string CartNumber { get; set; }
    public string ExpireDate { get; set; }
    public string CVV { get; set; }
}