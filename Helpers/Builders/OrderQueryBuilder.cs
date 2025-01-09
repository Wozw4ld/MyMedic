using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Builders
{
	public class OrderQueryBuilder
	{
		private Guid _userId;
		private bool _byDate;
		private bool _byPrice;
		private OrderStatus? _byStatus;
		private bool _byPaid;

		public OrderQueryBuilder ForUser(Guid userId)
		{
			_userId = userId;
			return this;
		}
		public OrderQueryBuilder ByDate()
		{
			_byDate = true;
			return this;
		}
		public OrderQueryBuilder ByPrice()
		{
			_byPrice = true;
			return this;
		}
		public OrderQueryBuilder WithStatus(OrderStatus status)
		{
			_byStatus = status;
			return this;
		}
		public OrderQueryBuilder ByPaid()
		{
			_byPaid = true;
			return this;
		}
		public OrderQuery Build()
		{
			return new OrderQuery
			{
				//UserId = _userId,
				ByStatus = _byStatus,
				ByDate = _byDate,
				ByPaid = _byPaid,
				ByPrice = _byPrice,
			};
		}
	}
	public class OrderQuery
	{
		//public Guid UserId { get; set; }
		public bool ByDate { get; set; }
		public bool ByPrice { get; set; }
		public OrderStatus? ByStatus { get; set; }
		public bool ByPaid { get; set; }
	}
}
