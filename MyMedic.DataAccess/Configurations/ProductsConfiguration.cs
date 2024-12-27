using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMedic.DataAccess.Models;

namespace MyMedic.DataAccess.Configurations
{
	public class ProductsConfiguration : IEntityTypeConfiguration<ProductsEntity>
	{
		public void Configure(EntityTypeBuilder<ProductsEntity> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasMany(p => p.Images)
				.WithOne(i => i.Product);
			builder.HasOne(p => p.Category)
				.WithMany(c => c.Products);
			builder.HasMany(p => p.Orders)
				.WithMany(o => o.Products);
		}
	}
}
