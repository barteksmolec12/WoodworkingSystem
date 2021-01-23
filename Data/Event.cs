using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
	public class Event
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartAssembley { get; set; }
        public DateTime EndAssembley { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }

    }
}
