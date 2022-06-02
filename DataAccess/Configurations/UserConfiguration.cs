using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
        

            builder.Property(u => u.Name).IsRequired().HasMaxLength(75);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();


            builder.Property(u => u.Password).IsRequired().HasMaxLength(512);

            builder.Property(u => u.Active).HasDefaultValue(false);

            builder.Property(u => u.Address).HasDefaultValue(null);
            builder.Property(u => u.Tel).HasDefaultValue(null);

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.ModifiedAt).HasDefaultValueSql(null);
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);

            builder.Property(u => u.Token).IsRequired();

        }
    }
}
