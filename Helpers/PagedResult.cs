using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
	public class PagedResult<T>
	{
		public List<T>? Items { get; set; }
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 0;
		public int TotalCount { get; set; } = 0;
		public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
	}
}
