using AKBlog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Configuration
{
    public class PostsConfiguration : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(m => m.ID).UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(150);
            builder.Property(m => m.Description).IsRequired().HasColumnType("text");
            builder.Property(m => m.ImageUrl).HasMaxLength(250);
            builder.Property(m => m.PostViewCount).IsRequired().HasColumnType("int");
            builder.Property(m => m.CategoryId).IsRequired().HasColumnType("int");
            builder.Property(m => m.UserId).IsRequired().HasColumnType("int");
            builder.Property(m => m.TagId).IsRequired().HasColumnType("int");
            
            builder.Property(m => m.CreatedUser);
            builder.Property(m => m.CreatedTime).HasColumnType("datetime2");
            builder.Property(m => m.UpdatedUser);
            builder.Property(m => m.UpdatedTime).HasColumnType("datetime2");
            builder.Property(m => m.IsActive);
            builder.ToTable("Posts");
        }
    }
}
