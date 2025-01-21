using Microsoft.AspNetCore.Mvc;
using StreamerAwards.Entities.DTOs;
using StreamerAwards.Entities.Entity_Models;
using StreamerAwards.Logic.Services;

namespace StreamerAwards.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _service.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(string id)
        {
            var category = _service.GetCategoryById(id);
            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryCreateUpdateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _service.AddCategory(category);
            return Ok("Category successfully added.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(string id, [FromBody] Category category)
        {
            try
            {
                _service.UpdateCategory(id, category);
                return Ok("Category successfully updated.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            try
            {
                _service.DeleteCategory(id);
                return Ok("Category successfully deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
      
    }
}
