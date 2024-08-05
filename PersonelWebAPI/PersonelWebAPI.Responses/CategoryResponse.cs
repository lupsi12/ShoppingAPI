using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses;

public class CategoryResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryResponse(Category entity)
    {
        this.Name = entity.Name;
        this.Description = entity.Description;
    }
}