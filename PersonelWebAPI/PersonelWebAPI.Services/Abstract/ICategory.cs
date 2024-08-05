using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract;

public interface ICategory
{
    List<CategoryResponse> GetAllCategory(string? name=null);
    CategoryResponse GetCategorybyId(int id);
    CategoryResponse AddCategory(CategoryCreateRequest categoryCreateRequest);
    void PartialUpdateCategory(int id, Dictionary<string, object> updates);
    void DeleteCategory(int id);
}