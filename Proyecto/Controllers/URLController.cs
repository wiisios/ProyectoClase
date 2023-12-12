using Microsoft.AspNetCore.Mvc;
using Proyecto.Data.Interfaces;
using Proyecto.Entities;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class URLController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        
        public URLController(IUrlService urlService, IUserService userService, ICategoryService categoryService )
        {
            _urlService = urlService;
            _userService = userService;
            _categoryService = categoryService;
          
        }

        [HttpGet()]
        public IActionResult GetFullUrl(string shorturl)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);

            string url = _urlService.GetFullURL(shorturl);

            if (url is null)
            {
                return NotFound();
            }
            _userService.DiscountShortAmount(userId);
            return Ok(url);
        }

        


        [HttpPost]
        public IActionResult CreateShortURL(string fullurl, int categoryId)
        {

            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);

            _userService.DiscountShortAmount(userId);

            Category existingCategory = _categoryService.GetById(categoryId);

            User currentUser = _userService.GetById(userId);

            URL url = _urlService.Create(fullurl, existingCategory, currentUser);

            return Ok(url);

        }




    }
}
