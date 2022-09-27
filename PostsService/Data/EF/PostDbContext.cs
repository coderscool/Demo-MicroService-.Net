using Microsoft.EntityFrameworkCore;
using PostsService.Data.Configuration;
using PostsService.Extension;
using PostsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Data.EF
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.Seed();
        }
        public DbSet<Post> Posts { get; set; }
    }
}
