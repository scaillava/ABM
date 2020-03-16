using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ABM.API.Infrastructure.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ABM.API
{
    public class Startup
    {
        private const string AppName = "ABM API Challenge";
        private const string AppVersion = "v1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                // requires using Microsoft.AspNetCore.Mvc.Formatters;
                options.ReturnHttpNotAcceptable = false;
                
                //options.OutputFormatters.RemoveType<StringOutputFormatter>();
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                ////options.UseCustomStringModelBinder();
                
                //options.AllowEmptyInputInBodyModelBinding = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddXmlSerializerFormatters();

            //services.AddMvc(options =>
            //{
            //    options.ReturnHttpNotAcceptable = true;
            //});
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddXmlSerializerFormatters();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(options =>
            {
                var documentation = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, documentation);
                options.IncludeXmlComments(filePath);
                options.DocumentFilter<LowercaseDocumentFilter>();
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc(AppVersion,
                    new Info
                    {
                        Title = AppName,
                        Version = AppVersion
                    });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            var rewriteOptions = new RewriteOptions();
            rewriteOptions.AddRedirect("^$", "swagger");
            app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"{AppVersion}/swagger.json", $"{AppName} {AppVersion}");
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRewriter(rewriteOptions);
        }
    }
}
