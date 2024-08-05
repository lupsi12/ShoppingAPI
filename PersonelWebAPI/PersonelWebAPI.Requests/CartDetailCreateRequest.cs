namespace PersonelWebAPI.Requests;

public class CartDetailCreateRequest
{
    public int CartId { get; set; }
    public int ProductId { get; set; } 
    public int InstantPrice { get; set; } 
}