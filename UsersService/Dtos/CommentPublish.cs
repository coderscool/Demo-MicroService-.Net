using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Dtos
{
    public class CommentPublish
    {
        public int PostId { get; set; }
        public string Event { get; set; }
    }
}
