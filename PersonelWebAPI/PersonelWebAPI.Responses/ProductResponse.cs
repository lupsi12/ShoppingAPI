using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses;

public class ProductResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; } 
    public int SupplierId { get; set; }

    public ProductResponse(Product entity)
    {
        this.Name = entity.Name;
        this.Description = entity.Description;
        this.Stock = entity.Stock;
        this.Price = entity.Price;
        this.CategoryId = entity.CategoryId;
        this.SupplierId = entity.SupplierId;
    }
}