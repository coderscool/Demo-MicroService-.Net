using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Dtos;
using UsersService.Models;

namespace UsersService.Data
{
    public interface ICommentsService
    {
        IEnumerable<Comment> GetAllComments();
        Task<Comment> GetById(int id);
        Task<int> CreateComment(CreateCommentDtos comment);
        Task<List<Comment>> GetCommentByPostId(int id);
    }
}
