using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ICategoryController
    {
        List<CategoryResponse> GetAllCategory(string? name = null);
        CategoryResponse GetCategoryById(int id);
        CategoryResponse AddCategory(CategoryCreateRequest categoryCreateRequest);
        void PartialUpdateCategory(int id, Dictionary<string, object> updates);
        void DeleteCategory(int id);
    }
}