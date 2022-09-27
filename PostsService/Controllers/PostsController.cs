using Microsoft.AspNetCore.Mvc;
using PostsService.Data;
using PostsService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] GetPostIdDtos request)
        {
            var comments = await _postsService.GetPostById(request.Id);
            if (comments == null)
                return BadRequest();
            return Ok(comments);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _postsService.CreatePost(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
