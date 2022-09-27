using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.AsyncDataService;
using UsersService.Data;
using UsersService.Dtos;
using UsersService.Migrations;
using UsersService.SyncDataService;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsService _commentService;
        private readonly ICommentDataClient _commentDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public CommentController(ICommentsService commentService, ICommentDataClient commentDataClient, IMessageBusClient messageBusClient)
        {
            _commentService = commentService;
            _commentDataClient = commentDataClient;
            _messageBusClient = messageBusClient;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDtos request)
        {
            var result = await _commentService.CreateComment(request);
            if (result == 0)
                return BadRequest();

            var comment = await _commentService.GetById(result);

            try
            {
                await _commentDataClient.TotalCount(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            try
            {
                var commentPublish = new CommentPublish()
                {
                    PostId = request.PostId,
                    Event = "Comment_Published"
                };
                _messageBusClient.PublishSetTotal(commentPublish);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetById), new { Id = result }, comment);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] GetCommentIdDtos request)
        {
            var comments = await _commentService.GetById(request.Id);
            if (comments == null)
                return BadRequest();
            return Ok(comments);
        }
        [HttpGet("comment")]
        public async Task<IActionResult> GetAllComment()
        {
            var result = _commentService.GetAllComments();
            return Ok(result);
        }
        [HttpGet("getid")]
        public async Task<IActionResult> GetCommentByPostId([FromQuery] GetCommentIdDtos request)
        {
            var comments = await _commentService.GetCommentByPostId(request.Id);
            if (comments == null)
                return BadRequest();
            return Ok(comments);
        }
    }
}
