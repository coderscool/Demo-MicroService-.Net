using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Letter { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}
