using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Dtos
{
    public class GenericMessageDto
    {
        public int PostId { get; set; }
        public string Event { get; set; }
    }
}
