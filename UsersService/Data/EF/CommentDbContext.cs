using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Data.Configuration;
using UsersService.Extension;
using UsersService.Models;

namespace UsersService.Data.EF
{
    public class CommentDbContext :DbContext
    {
        public CommentDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.Seed();
        }
        public DbSet<Comment> Comments { get; set; }
    }
}
