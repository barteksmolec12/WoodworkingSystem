using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public class Machine:BaseEntity
	{
		
		public string  Image { get; set; }
		public int WoodmakerId { get; set; }
		public string State { get; set; }
	}
}
