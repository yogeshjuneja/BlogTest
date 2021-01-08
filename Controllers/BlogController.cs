using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Newtonsoft.Json;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTImplementation.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogController : ControllerBase
    {
        public readonly IBlogService BlogService;
        public BlogController(IBlogService IBlogService)
        {
            BlogService = IBlogService;
        }

        // GET: api/<BlogController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(BlogService.GETAllBolgs(eBlogService.Select)));
        }

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Insert(BlogClass objBlogClass)
        {
            return Ok(BlogService.InsertorUpdate(objBlogClass, eBlogService.Insert));
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogClass objBlogClass)
        {
            objBlogClass.BLOGID = id;
            return Ok(BlogService.InsertorUpdate(objBlogClass, eBlogService.Update));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id, BlogClass objBlogClass=null)
        {
            objBlogClass.BLOGID = id;
            return Ok(BlogService.InsertorUpdate(objBlogClass, eBlogService.Delete));
        }
    }
}
