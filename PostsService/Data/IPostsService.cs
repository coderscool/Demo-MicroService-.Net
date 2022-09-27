using PostsService.Dtos;
using PostsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Data
{
    public interface IPostsService
    {
        IEnumerable<Post> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task<int> CreatePost(int PostId);
        bool SaveChange();
        void Create(int PostId);

    }
}
