using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Dtos
{
    public class CreateCommentDtos
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public int PostId { get; set; }
    }
}
