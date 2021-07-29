using QuinntyneBrown.Api.Data;
using QuinntyneBrown.Api.Extensions;
using QuinntyneBrown.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace QuinntyneBrown.Api
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "",
                    Description = "",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = ""
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowCredentials()));

            services.AddValidation(typeof(Startup));

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(IQuinntyneBrownDbContext));

            services.AddTransient<IQuinntyneBrownDbContext, QuinntyneBrownDbContext>();

            services.AddDbContext<QuinntyneBrownDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(QuinntyneBrown.Api))
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();
            });

            services.AddControllers();
        }
    }
}
