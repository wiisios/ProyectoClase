﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Entities;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RedirectController : ControllerBase
    {
        private readonly URLService _urlService;
        private readonly URLContext _urlContext;
        public RedirectController(URLService urlService, URLContext urlContext )
        {
            _urlService = urlService;
            _urlContext = urlContext;
        }

        [HttpGet]
        public IActionResult GetShortUrl(string fullurl)
        {
            URL? url = _urlService.GetURL(fullurl);

            if (url is null)
            {
                return NotFound();
            }
            return Ok(url.ShortUrl);
        }

        [HttpGet("hola")]
        public IActionResult GetUrl()
        {
            return Ok(_urlContext.Urls.ToList());
        }

        [HttpPost]
        public IActionResult CreateURL(string fullurl)
        {
            
            URL url = _urlService.Create(fullurl);

            return Ok(url.ShortUrl);
            
        }




    }
}
