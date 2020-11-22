using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class ProductDetails
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
		public string Material { get; set; }
		public enum EMaterial { Dąb = 0, Jesion = 1, Orzech = 2, Sosna = 3 }
		public string Color { get; set; }
		public string ColorLegs { get; set; }
		public enum EColors { Bezbarwny = 0, Biały = 1, Czarny =2}
		public int Height { get; set; }
		public int Width { get; set; }
		public int Count { get; set; }
		public int CountM2 { get; set; }

	}
}
