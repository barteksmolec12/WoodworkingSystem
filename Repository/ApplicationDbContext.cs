using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Category> Category { get; set; }
		public DbSet<JoineryOrder> JoineryOrders { get; set; }
		public DbSet<JoineryOrderDetails> JoineryOrderDetails { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductDetails> ProductDetails { get; set; }
		public DbSet<Machine> Machines { get; set; }
		public DbSet<Woodmaker> Woodmakers { get; set; }
		public DbSet<ShoppingCartClient> ShoppingCartClients { get; set; }
	}
}
