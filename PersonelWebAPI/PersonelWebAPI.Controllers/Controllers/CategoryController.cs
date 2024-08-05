using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.UnitOfWork.UnitOfWork;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Managers.Concretes;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public CategoryResponse AddCategory([FromBody] CategoryCreateRequest categoryCreateRequest)
        {
            var response = _unitOfWork.CategoryRepository.AddCategory(categoryCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.DeleteCategory(id);
            _unitOfWork.Commit();
        }


        [HttpGet("{id}")]
        public CategoryResponse GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepository.GetCategorybyId(id);
        }
        [HttpGet]
        public List<CategoryResponse> GetAllCategory([FromQuery] string? name = null)
        {
            return _unitOfWork.CategoryRepository.GetAllCategory(name);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateCategory(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.CategoryRepository.PartialUpdateCategory(id, updates);
            _unitOfWork.Commit();
        }
    }
}