namespace Service.Models.Payload.Requests.Order;

public class CreateOrderRequest
{
    public int MemberId { get; set; }
    public int ProductId { get; set; }
    public string RequiredDate { get; set; } = null!;
    public string ShippedDate { get; set; } = null!;
    public double Freight { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }
}