using Microsoft.EntityFrameworkCore;
using PostsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                 new Post() { Id = 1, Title = "Champion League", Letter = "Trận chung kết", Image = "cde", Count = 1 },
                 new Post() { Id = 2, Title = "Laugh Tale", Letter = "Ta sẽ trở thành vua hải tặc", Image = "ghi", Count = 1 },
                 new Post() { Id = 3, Title = "Team châu phi", Letter = "Dự án trang trại", Image = "gkl", Count = 1 }
                 );

        }
    }
}
