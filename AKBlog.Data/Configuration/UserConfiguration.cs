using AKBlog.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(m => m.ID).UseIdentityColumn();
            builder.Property(m => m.UserName).IsRequired().HasMaxLength(250);
            builder.Property(m => m.Password).IsRequired().HasMaxLength(250);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(150);
            builder.Property(m => m.Surname).IsRequired().HasMaxLength(150);
            builder.Property(m => m.EMail).IsRequired().HasMaxLength(250);
            builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedUser);
            builder.Property(m => m.CreatedTime).HasColumnType("datetime2");
            builder.Property(m => m.UpdatedUser);
            builder.Property(m => m.UpdatedTime).HasColumnType("datetime2");
            builder.Property(m => m.IsActive);
            builder.ToTable("Users");
        }
    }
}
