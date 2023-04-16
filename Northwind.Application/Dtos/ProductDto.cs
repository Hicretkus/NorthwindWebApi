using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Dtos
{
	public class ProductDto
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string QuantityPerUnit { get; set; }
	}
}
