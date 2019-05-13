using AqarPress.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Diagnostics;
using System.Linq;

namespace AqarPress.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            AqarPress.Core.Init.Empty();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(x => x.GetTypes())
                                 .Where(p => typeof(ICreateInScope).IsAssignableFrom(p) && p.IsClass)
                                 .ToList();

            types.ForEach(x => services.AddSingleton(x));

            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                                c => c.SetTraceLevel(TraceLevel.Verbose)
                                        .AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory))
                                        .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureApplication(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureApplication(IApplicationBuilder application)
        {
            Adapter.ConnectionString = Configuration["connectionString"];
        }


    }
}