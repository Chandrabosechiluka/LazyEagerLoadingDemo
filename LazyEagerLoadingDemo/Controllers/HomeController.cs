using LazyEagerLoadingDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LazyEagerLoadingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("lazy-loading")]
        public async Task<IActionResult> GetLazyLoading([FromServices] MyContext context)
        {
            var authors = await context.Authors.ToListAsync(); 
            var books = authors.SelectMany(a => a.Books); 
            return Ok(authors);
        }

        [HttpGet("eager-loading")]
        public async Task<IActionResult> GetEagerLoading(MyContext context)
        {
            var authorsWithBooks = await context.Authors
                .Include(a => a.Books) 
                .ToListAsync();
            return Ok(authorsWithBooks);
        }
    }
}
