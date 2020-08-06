using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using TuinAppApi.Data;
using TuinAppApi.Data.Repositories;
using TuinAppApi.Models;

namespace TuinAppApi
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
            services.AddControllers();

            services.AddDbContext<TuinDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("TuinenContext")));

            services.AddDbContext<OmgevingDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("OmgevingContext")));

            services.AddScoped<ITuinenRepository, TuinRepository>();
            services.AddScoped<IOmgevingRepository, OmgevingRepository>();
            services.AddScoped<IGebruikerRepository, GebruikerRepository>();
            services.AddScoped<TuinDbInitializer>();
            services.AddScoped<OmgevingDbInitializer>();

            services.AddIdentity<IdentityUser, IdentityRole>(a => a.User.RequireUniqueEmail = true).AddEntityFrameworkStores<TuinDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            //Register the Swagger services
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "TuinAPI";
                c.Version = "v1";
                c.Description = "Info over API van de TuinApp";
                c.AddSecurity("JWT", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey, //use api key for authorization. an api key is a token that a client provides when making api calls
                    In = OpenApiSecurityApiKeyLocation.Header, //token is passed in the header
                    Name = "Authorization", // name of the header to be used
                    Description = "Type into the textbox: Bearer {JWT token}." // description above textfield to enter bearer token
                });
                c.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            //services.AddSwaggerDocument();

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));

            services.AddAuthentication(x => { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(x => {
                    x.SaveToken = true; x.TokenValidationParameters = new TokenValidationParameters { 
                        ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                        , ValidateIssuer = false, ValidateAudience = false, RequireExpirationTime = true 
                    }; 
                });

            services.AddAuthorization(options => { 
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin")); 
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TuinDbInitializer tuinDbInitializer, OmgevingDbInitializer omgevingDbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //register swagger and middleware
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            tuinDbInitializer.InitializeData().Wait();
            omgevingDbInitializer.InitializeData(); //.wait();
        }
    }
}
