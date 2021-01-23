using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoineryUI.Models
{
	public class ShopAreaViewModel
	{
		public IEnumerable<Product> products;
		public IEnumerable<Category> categories;
	}
}
