using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Data;
using System.Data.SqlClient;
using Service;
using Service.Abstract;

namespace JoineryUI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddSignalR();
			services.AddControllersWithViews();
			services.ConfigureApplicationCookie(options =>

			{

				options.LoginPath = $"/Identity/Account/Login";

				options.LogoutPath = $"/Identity/Account/Logout";

				options.AccessDeniedPath = $"/Identity/Account/AccessDenied";

			});

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
			services.AddRazorPages().AddRazorRuntimeCompilation();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<ICategoryService, CategoryService>();
		    services.AddTransient<IMachineService, MachineService>();
			services.AddTransient<IEventService, EventService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IEntryService, EntryService>();






		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
				app.UseCors("MyPolicy");
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseCors("MyPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapHub<SignalrServer>("/signalrServer");
				endpoints.MapRazorPages();
			});
		}
	}
}
