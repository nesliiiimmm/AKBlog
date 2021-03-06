using AKBlog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Configuration
{
    public class TagsConfiguration : IEntityTypeConfiguration<Tags>
    {
        public void Configure(EntityTypeBuilder<Tags> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(m => m.ID).UseIdentityColumn();
            builder.Property(m => m.Tag).IsRequired().HasMaxLength(250);
          
            builder.Property(m => m.CreatedUser);
            builder.Property(m => m.CreatedTime).HasColumnType("datetime2");
            builder.Property(m => m.UpdatedUser);
            builder.Property(m => m.UpdatedTime).HasColumnType("datetime2");
            builder.Property(m => m.IsActive);
            builder.ToTable("Tags");
        }
    }
}
