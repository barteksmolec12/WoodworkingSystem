using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class Product:BaseEntity
	{

		[Required]
		public string ProductName { get; set; }
		[Required]
		public string CategoryId  { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
		public string  Description { get; set; }
		public string Image  { get; set; }
		[Required]
		public double Price  { get; set; }
	}
}
