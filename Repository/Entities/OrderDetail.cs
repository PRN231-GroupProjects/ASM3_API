using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities;

public class OrderDetail
{
    [Key, Column(Order = 1)]
    public int OrderId { get; set; }
    [Key, Column(Order = 2)]
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }

    // Navigations
    public Product Product { get; set; }
    public Order Order { get; set; }
}