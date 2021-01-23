
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	public class ApplicationUser : IdentityUser
	{
		
		[Display(Name = "Imię i nazwisko")]
		public string Name { get; set; }
		[Display(Name = "Ulica")]
		public string StreetAddress { get; set; }
		[Display(Name = "Miejscowość")]
		public string City { get; set; }
		[Display(Name = "Stan")]
        public string State { get; set; }
		[Display(Name = "Kod pocztowy")]
		public string PostalCode { get; set; }
		
		[Display(Name = "Powtórz hasło")]
		public string ConfirmPassword { get; set; }
		public long Token { get; set; }
	}
}
