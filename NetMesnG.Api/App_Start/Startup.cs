using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetMesnG.Api.ConfigModels;
using NetMesnG.Api.Extensions;

namespace NetMesnG.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //ToDo: write get configurations.
            // var some = configuration["SwaggerOpenApiInfo"];
            // _apiInfo = configuration.Get<SwaggerOpenApiInfo>(options => Configuration.GetSection("SwaggerOpenApiInfo"));
        }

        public IConfiguration Configuration { get; }
        private SwaggerOpenApiInfo _apiInfo;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = Configuration["SwaggerOpenApiInfo:Title"],
                        Version = Configuration["SwaggerOpenApiInfo:Version"],
                        Contact = new()
                        {
                            Email = Configuration["SwaggerOpenApiInfo:OpenApiContacts:Email"],
                            Name = Configuration["SwaggerOpenApiInfo:OpenApiContacts:Name"]
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetMesnG.Api v1"));
            }

            app.UseHttpsRedirection();

            app.ExceptionHandling();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}