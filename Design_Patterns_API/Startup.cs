using Design_Patterns;
using Design_Patterns.SOLID;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Patterns_API
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

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Design_Patterns_API", Version = "v1" });
            });

            services.AddScoped<SingleResponsibilty, SingleResponsibilty>();
            services.AddScoped<FruitsBasket, FruitsBasket>();
            services.AddScoped<Persistence, Persistence>();

            services.AddScoped<OpenClosed, OpenClosed>();
            services.AddScoped<Design_Patterns.SOLID.Environment, DevEnvironment>();

            services.AddScoped<LiskovSubstitution, LiskovSubstitution>();
            services.AddScoped<Grocery, Fruits>();

            services.AddScoped<InterfaceSegregation, InterfaceSegregation>();
            services.AddScoped<IMobileNotification, MobileNotification>();
            services.AddScoped<IEmailNotification, EmaileNotification>();

            services.AddScoped<DependencyInversion, DependencyInversion>();
            services.AddScoped<IServerFilterable, ServerManager>();

            services.AddScoped<BuilderPattern, BuilderPattern>();

            services.AddScoped<SingletonChecker, SingletonChecker>();

            services.AddScoped<Yougurt, Yougurt>();
            services.AddScoped<FactoryPattern, FactoryPattern>();


            services.AddScoped<AdapterPattern, AdapterPattern>();

            services.AddScoped<OrderManagement, OrderManagement>();
            services.AddScoped<FacadePattern, FacadePattern>();

            services.AddScoped<DecoratorPattern, DecoratorPattern>();

            services.AddScoped<ObeserverPattern, ObeserverPattern>();

            services.AddScoped<IReponseFormatStragy, XMLResponseStrategy>();
            services.AddScoped<ResponseProcessor, ResponseProcessor>();
            services.AddScoped<StrategyPattern, StrategyPattern>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Design_Patterns_API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
