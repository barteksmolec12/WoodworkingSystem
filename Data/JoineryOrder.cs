using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
	public class JoineryOrder:BaseEntity
	{
		
		[Required]
		public int UserId { get; set; }
		[Required]
		public DateTime DataOrder { get; set; }
		public DateTime DateOrderEnd { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
		[Required]
		public string Status  { get; set; }
	}
}
