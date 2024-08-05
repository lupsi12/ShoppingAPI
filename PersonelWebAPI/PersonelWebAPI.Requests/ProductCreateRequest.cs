namespace PersonelWebAPI.Requests;

public class ProductCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; } 
    public int SupplierId { get; set; } 
}