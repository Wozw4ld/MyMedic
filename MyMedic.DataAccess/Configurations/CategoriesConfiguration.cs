using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMedic.DataAccess.Models;

namespace MyMedic.DataAccess.Configurations
{
	public class CategoriesConfiguration : IEntityTypeConfiguration<CategoriesEntity>
	{
		public void Configure(EntityTypeBuilder<CategoriesEntity> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasMany(u => u.Products)
				.WithOne(o => o.Category);
			builder.HasOne(p => p.ParentCategory)
				.WithMany(p => p.SubCategories);
		}
	}
}
