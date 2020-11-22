using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class JoineryOrderDetails
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int JoineryOrderId { get; set; }
		[ForeignKey("JoineryOrderId")]
		public virtual JoineryOrder JoineryOrder { get; set; }
		[Required]
		public int ProductDetailsId  { get; set; }
		[Required]
		public int WoodmakerId { get; set; }
		[Required]
		public string Status  { get; set; }
	}
}
