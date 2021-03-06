using AKBlog.Core.Model;
using AKBlog.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AKBlog.Data.Contexts
{
    public class AKBlogMSSQLDBContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DevConnection"]);
        }
        public AKBlogMSSQLDBContext(DbContextOptions<AKBlogMSSQLDBContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new TagsConfiguration());
            builder.ApplyConfiguration(new PostsConfiguration());
            builder.ApplyConfiguration(new CommentsConfiguration());

        }
    }
}
