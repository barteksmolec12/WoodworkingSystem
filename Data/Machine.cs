using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class Machine
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string  Image { get; set; }
		public string WoodmakerId { get; set; }
		[ForeignKey("WoodmakerId")]
		public virtual ApplicationUser ApplicationUser { get; set; }
		public string State { get; set; }
	}
}
