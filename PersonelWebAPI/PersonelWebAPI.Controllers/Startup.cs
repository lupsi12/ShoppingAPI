using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PersonelWebAPI.Controllers.Controllers;
using PersonelWebAPI.UnitOfWork.UnitOfWork;
using PersonelWebAPI.DataAccess;
using PersonelWebAPI.JWT;
using PersonelWebAPI.Managers.Concretes;

namespace PersonelWebAPI.Controllers
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork.UnitOfWork>();
            services.AddSingleton<WebAPIDbContext>();
            services.AddSingleton<SupplierManager>();
            services.AddSingleton<JwtTokenService>();
            services.AddSingleton<PersonelManager>();
            services.AddSingleton<AddresManager>();
            services.AddSingleton<AdminManager>();
            services.AddSingleton<CartDetailManager>();
            services.AddSingleton<CartManager>();
            services.AddSingleton<SaleManager>();
            services.AddSingleton<ProductManager>();
            services.AddSingleton<CategoryManager>();
            services.AddControllers();
            services.AddSwaggerDocument();

            // JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization();

            // CORS Policy
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

            app.UseCors("AllowReactApp");
            app.UseRouting();
            app.UseAuthentication(); // JWT kimlik doğrulama için eklenmesi gereken middleware
            app.UseAuthorization(); // Yetkilendirme işlemleri için eklenmesi gereken middleware
            

            app.UseOpenApi(); // Swagger OpenAPI dokümantasyonu için
            app.UseSwaggerUi();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
