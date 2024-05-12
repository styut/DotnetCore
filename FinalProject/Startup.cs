// using System;
// using System.Text;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.OpenApi.Models;
// using Taskking.Services;

//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddAuthentication(options =>
//             {
//                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//             })
//             .AddJwtBearer(cfg =>
//             {
//                 cfg.RequireHttpsMetadata = false;
//                 cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
//             });
//             services.AddAuthorization(cfg =>
//                 {
//                     cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
//                     cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));
                    
//                 });

//             services.AddControllers();
//             services.AddSwaggerGen(c =>
//             {
//                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taskking", Version = "v1" });
//                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                 {
//                     In = ParameterLocation.Header,
//                     Description = "Please enter JWT with Bearer into field",
//                     Name = "Authorization",
//                     Type = SecuritySchemeType.ApiKey
//                 });
//                 c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//                 { new OpenApiSecurityScheme
//                         {
//                          Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
//                         },
//                     new string[] {}
//                 }
//                 });
//             });
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//                 app.UseSwagger();
//                 app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FBI v1"));
//             }

//             //app.UseHttpsRedirection();

//             app.UseRouting();

//             app.UseAuthentication();

//             app.UseAuthorization();

//             app.UseEndpoints(endpoints =>
//             {
//                 endpoints.MapControllers();
//             });
//         }
//     }

using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Taskking.Services;
using Taskking.Utilities; // Add this namespace for Utilities

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
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
        });
        services.AddAuthorization(cfg =>
        {
            cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
            cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));
        });

        // Register services using the Utilities class
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taskking", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            { new OpenApiSecurityScheme
                    {
                     Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                    },
                new string[] {}
            }
            });
        });

        // Call the AddTaskServices method to register Task and User services
        services.AddTask();
        services.AddHttpContextAccessor();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FBI v1"));
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();   

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

