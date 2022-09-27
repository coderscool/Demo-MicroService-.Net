using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Models;

namespace UsersService.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                 new Comment() { Id = 1, PostId = 1, Count = 0, Status = "SOFM" },
                 new Comment() { Id = 2, PostId = 2, Count = 0, Status = "SN" },
                 new Comment() { Id = 3, PostId = 3, Count = 0, Status = "WBG" }
                 );

        }
    }
}
