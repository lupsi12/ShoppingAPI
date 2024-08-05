﻿using PersonelWebAPI.Business.UnitOfWork;
using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Managers.Concretes;

namespace PersonelWebAPI.Controllers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<WebAPIDbContext>();
            services.AddSingleton<SupplierManager>();
            services.AddSingleton<PersonelManager>();
            services.AddSingleton<AddresManager>();
            services.AddSingleton<AdminManager>();
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseCors("AllowReactApp");

            app.UseRouting();
            app.UseOpenApi();//swagger
            app.UseSwaggerUi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
