using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Data.Interfaces;
using Proyecto.Entities;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IActionResult GetOneByName(string name)
        {
            if (name == string.Empty)
            {
                return BadRequest("El nombre ingresado debe contener al menos 1 caracter");
            }

            Category category = _categoryService.GetByName(name);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        [HttpPost]
        
        public IActionResult CreateCategory(string name)
        {

            try
            {
                _categoryService.Create(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", name);
        }
    }
}
