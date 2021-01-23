using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class Entry
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public DateTime DateOfEntry { get; set; }
		public DateTime? ExitDate { get; set; }
		public string TimeIn { get; set; }
		public string TimeOut { get; set; }
		public string DayOfEntry { get; set; }
		public string EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
