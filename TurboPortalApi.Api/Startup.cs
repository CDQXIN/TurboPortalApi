using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TurboPortalApi.Api.Options;
using TurboPortalApi.Core;

namespace TurboPortalApi.Api
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
            services.AddCors(ac => ac.AddPolicy("any", ap => ap.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddDbContext<TurboPortalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConStr")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ItemOptions>();
            //获取反射对象
            var asm = Assembly.Load("TurboPortalApi.Services");
            //获取对象中所有的非抽象类
            var serviceTypes = asm.GetTypes().Where(x => !x.GetTypeInfo().IsAbstract && !x.GetTypeInfo().IsEnum);
            foreach (var serviceType in serviceTypes)
            {
                foreach (var serviceTypeInterface in serviceType.GetInterfaces())
                {
                    services.AddScoped(serviceTypeInterface, serviceType);
                }
            }
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("any");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
