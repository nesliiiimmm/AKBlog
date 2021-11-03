using AKBlog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Configuration
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(m => m.ID).UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Comment).IsRequired().HasColumnType("text");
            builder.Property(m => m.EMail).IsRequired().HasMaxLength(250);
            builder.Property(m => m.PostId).IsRequired().HasColumnType("int");
            builder.HasOne(m => m.Post).WithMany(m=>m.Comments).HasForeignKey(m => m.PostId);
            builder.Property(m => m.UserId).IsRequired().HasColumnType("int");
            builder.HasOne(m => m.User).WithMany(m => m.Comments).HasForeignKey(m => m.UserId);

            builder.Property(m => m.CreatedUser);
            builder.Property(m => m.CreatedTime).HasColumnType("datetime2");
            builder.Property(m => m.UpdatedUser);
            builder.Property(m => m.UpdatedTime).HasColumnType("datetime2");
            builder.Property(m => m.IsActive);
            builder.ToTable("Comments");
        }
    }
}
