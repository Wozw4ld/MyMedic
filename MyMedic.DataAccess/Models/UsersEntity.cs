using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Models
{
	public class UsersEntity
	{
		public Guid Id { get; set; }
		public string UserEmail { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
		public string UserFullName { get; set; } = string.Empty;

		public List<OrdersEntity> Orders { get; set; } = new();
	}
}
