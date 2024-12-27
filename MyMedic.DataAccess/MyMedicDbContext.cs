using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Configurations;
using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess
{
	public class MyMedicDbContext(DbContextOptions<MyMedicDbContext> options) : DbContext (options)
	{
		public DbSet<UsersEntity> Users { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
		public DbSet<ProductsEntity> Products { get; set; }
		public DbSet<OrdersEntity> Orders { get; set; }
		public DbSet<CategoriesEntity> Categories { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsersConfiguration());
			modelBuilder.ApplyConfiguration(new OrdersConfiguration());
			modelBuilder.ApplyConfiguration(new ProductImagesConfiguration());
			modelBuilder.ApplyConfiguration(new ProductsConfiguration());
			modelBuilder.ApplyConfiguration(new OrdersConfiguration());
			base.OnModelCreating(modelBuilder);
		}

	}
}
