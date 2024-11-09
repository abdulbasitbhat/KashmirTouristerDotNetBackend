using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KashmiriTourister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BlogsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("allBlogs")]
        public IActionResult GetAllBlogs()
        {
            var blogs = dbContext.Blogs.ToList();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("id/{id:guid}")]
        public IActionResult getBlogById(Guid id)
        {
            var Blog = dbContext.Blogs.Find(id);
            if (Blog is null)
            {
                return NotFound();
            }
            return Ok(Blog);
        }

        [HttpPost]
        [Route("addBlog")]
        public IActionResult AddBlog(AddBlogDTO addBlogDTO)
        {
            var BlogsEntity = new Blogs()
            {
                image = addBlogDTO.image,
                title = addBlogDTO.title,
                subtitle = addBlogDTO.subtitle,
                properties = addBlogDTO.properties,
                blog = addBlogDTO.blog
            };

            dbContext.Blogs.Add(BlogsEntity);
            dbContext.SaveChanges();
            return Ok(BlogsEntity);
        }

        [HttpDelete]
        [Route("deleteBlog/{id:guid}")]
        public IActionResult deleteBlog(Guid id)
        {
            var Blog = dbContext.Blogs.Find(id);
            if(Blog is null)
            {
                return NotFound();
            }
            dbContext.Blogs.Remove(Blog);
            dbContext.SaveChanges();
            return Ok(Blog);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public IActionResult updateBlog(Guid id, UpdateBlogDTO updateBlogDTO)
        {
            var Blog = dbContext.Blogs.Find(id);
            if (Blog is null)
            {
                return NotFound();
            }
            Blog.image = updateBlogDTO.image;
            Blog.title = updateBlogDTO.title;
            Blog.subtitle = updateBlogDTO.subtitle;
            Blog.properties = updateBlogDTO.properties;
            Blog.blog = updateBlogDTO.blog;

            dbContext.SaveChanges();
            return Ok(Blog);

        }
    }
}
