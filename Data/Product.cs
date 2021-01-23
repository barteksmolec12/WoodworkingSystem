using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class Product

	{
		[Key]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nazwa produktu")]
		public string ProductName { get; set; }
		[Required]
		[Display(Name = "Kategoria")]
		public int CategoryId  { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
		[Display(Name = "Opis")]
		public string  Description { get; set; }
		[Display(Name = "Zdjęcie")]
		public string Image  { get; set; }
		[Required]
		[Display(Name = "Cena")]
		public double Price  { get; set; }
	}
}
