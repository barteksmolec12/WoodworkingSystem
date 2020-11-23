using Microsoft.Extensions.DependencyInjection;
using System;

namespace Resolver
{
	public class Registrator
	{
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<VideoContext>();
            services.AddScoped<IVideoService, VideoService>();
        }
    }
}
