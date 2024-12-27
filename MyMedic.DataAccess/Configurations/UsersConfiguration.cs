using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Configurations
{
	public class UsersConfiguration : IEntityTypeConfiguration<UsersEntity>
	{
		public void Configure(EntityTypeBuilder<UsersEntity> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasMany(u => u.Orders)
				.WithOne(o => o.User);
		}
	}
}
