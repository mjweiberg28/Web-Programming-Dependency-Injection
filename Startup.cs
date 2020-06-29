﻿using DependencyInjection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebProgramming;

namespace DependencyInjection
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<ConsoleLogger>();
            services.AddSingleton<ILogger>(ConsoleLogger.Instance);
            services.AddSingleton<IDatabase, MemoryDatabase>();

            services.AddScoped<IRequestIdGenerator, RequestIdGenerator>();
            services.AddScoped<StopwatchService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseCors(policy => policy
			   .AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader()
			   .WithExposedHeaders(new string[] { "request-id", "stopwatch" }));

			app.UseStaticFiles();

			if (env.IsDevelopment())
            {
                app.UseExceptionHandler(ErrorHandler.HandleError);
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
