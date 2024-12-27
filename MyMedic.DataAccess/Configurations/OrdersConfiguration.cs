using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMedic.DataAccess.Models;

namespace MyMedic.DataAccess.Configurations
{
	public class OrdersConfiguration : IEntityTypeConfiguration<OrdersEntity>
	{
		public void Configure(EntityTypeBuilder<OrdersEntity> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId);
			builder.HasMany(o => o.Products)
			.WithMany(p => p.Orders)
			.UsingEntity(j => j.ToTable("OrderProducts"));
		}
	}
}
