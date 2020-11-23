using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
	public class Woodmaker
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
	}
}
