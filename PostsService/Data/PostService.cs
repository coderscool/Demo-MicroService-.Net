using PostsService.Data.EF;
using PostsService.Dtos;
using PostsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Data
{
    public class PostService : IPostsService
    {
        private readonly PostDbContext _context;
        public PostService(PostDbContext context)
        {
            _context = context;
        }

        public void Create(int PostId)
        {
            var post = _context.Posts.Find(PostId);
            if (post == null) throw new Exception("cannot find a post");

            post.Count = 5;

        }

        public async Task<int> CreatePost(int PostId)
        {
            Console.WriteLine($"--> Log Post {PostId}");
            var pos = await _context.Posts.FindAsync(PostId);
            Console.WriteLine($"--> Log Post {pos.Title}");
            if (pos == null) throw new Exception("cannot find a post");

            pos.Count = 5;
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public async Task<Post> GetPostById(int PostId)
        {
            var comment = await _context.Posts.FindAsync(PostId);
            return comment;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
