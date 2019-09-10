using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.API.Extensions;
using ToDo.Core.Options;
using ToDo.Core.Utils;
using ToDo.Data;

namespace ToDo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ToDoDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(DictionaryResources.DbConnection)));
            services.AddMapper();
            services.AddDefaultCors();
            services.AddDefaultIdentity();
            services.AddJwtAuth(Configuration);
            services.Configure<ConfigurationOptions>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(DictionaryResources.AllowAllHeaders);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
