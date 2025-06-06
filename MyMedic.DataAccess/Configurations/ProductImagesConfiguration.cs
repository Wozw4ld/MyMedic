﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMedic.DataAccess.Models;

namespace MyMedic.DataAccess.Configurations
{
	public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
	{
		public void Configure(EntityTypeBuilder<ProductImages> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasOne(i => i.Product)
				.WithMany(p => p.Images);

			
		}
	}
	public class CategoryImagesConfiguration : IEntityTypeConfiguration<CategoryImages>
	{
		public void Configure(EntityTypeBuilder<CategoryImages> builder)
		{
			builder.HasOne(i => i.Category)
			.WithMany(i => i.Images);
		}
	}
}
