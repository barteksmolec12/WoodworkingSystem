using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoineryUI.Models
{
	public class ShopManagmentViewModel
	{
		public Product Product { get; set; }
		public List <Product> AllProducts{ get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
