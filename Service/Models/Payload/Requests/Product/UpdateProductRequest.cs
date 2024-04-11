namespace Service.Models.Payload.Requests.Products;

public class UpdateProductRequest
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = null!;
    public double Weight { get; set; }
    public double UnitPrice { get; set; }
    public int UnitInStock { get; set; }
}