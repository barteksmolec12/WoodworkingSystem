﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class ShoppingCartClient
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ProducDetailsId { get; set; }
		[ForeignKey("ProducDetailsId")]
		public virtual ProductDetails ProductDetails { get; set; }
	}
}
