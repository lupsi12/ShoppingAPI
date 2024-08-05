using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Managers.Concretes
{
    public class CategoryManager : ICategory
    {
        private readonly WebAPIDbContext _context;
        public CategoryManager(WebAPIDbContext context)
        {
            _context = context;
        }

        public List<CategoryResponse> GetAllCategory(string? name = null)
        {
            IQueryable<Category> query = _context.Categories;
            if (name != null)
            {
                query = query.Where(p => p.Name == name );
            }
            List<CategoryResponse> categoryResponses = query.Select(p => new CategoryResponse(p))
                .ToList();
            return categoryResponses;
        }

        public CategoryResponse GetCategorybyId(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null) 
            {
                return null;
            }
            CategoryResponse categoryResponse = new CategoryResponse(category);
            return categoryResponse;
        }

        public CategoryResponse AddCategory(CategoryCreateRequest categoryCreateRequest)
        {
            Category category = new Category();
            category.CreatedDate = DateTime.Now;
            category.Name = categoryCreateRequest.Name;
            category.Description = categoryCreateRequest.Description;
            _context.Categories.Add(category);
            CategoryResponse categoryResponse = new CategoryResponse(category);
            return categoryResponse;
        }
       
        

        public void PartialUpdateCategory(int id, Dictionary<string, object> updates)
        {
            
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "description":
                            category.Description = update.Value.ToString();
                            break;
                        case "name":
                            category.Name = update.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DeleteCategory(int id)
        {
            var deleteCategory = _context.Categories.Find(id);

            if (deleteCategory != null)
            {
                _context.Categories.Remove(deleteCategory);
            }
        }
    }
}
