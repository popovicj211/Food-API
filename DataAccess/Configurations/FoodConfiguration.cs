using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
   public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Price).IsRequired();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.ModifiedAt).HasDefaultValueSql(null);
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        }
    }
}
