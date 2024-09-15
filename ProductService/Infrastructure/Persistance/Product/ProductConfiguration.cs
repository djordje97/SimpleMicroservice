using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Core.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Product> builder)
        {
            builder.ToTable("product");

            builder.Property(x => x.Id).HasColumnName("id").HasConversion(x => x.ToString(), x => new Guid(x));
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.Property(x => x.Price).HasColumnName("price");

            builder.HasKey(x => x.Id);
        }
    }
}