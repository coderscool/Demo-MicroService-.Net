using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Data.EF;
using UsersService.Dtos;
using UsersService.Models;

namespace UsersService.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly CommentDbContext _context;
        public CommentsService(CommentDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateComment(CreateCommentDtos comment)
        {
            var com = new Comment()
            {
                Status = comment.Status,
                PostId = comment.PostId,
                Count = 0
            };
            _context.Comments.Add(com);
            await _context.SaveChangesAsync();
            return com.Id;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public async Task<Comment> GetById(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment;
        }

        public async Task<List<Comment>> GetCommentByPostId(int id)
        {
            var query = from c in _context.Comments
                        where c.PostId == id
                        select new { c };

            var comment = await query.Select(x => new Comment()
            {
                Id = x.c.Id,
                Count = x.c.Count,
                Status = x.c.Status,
                PostId = x.c.PostId
            }).ToListAsync();

            return comment;
        }
    }
}
