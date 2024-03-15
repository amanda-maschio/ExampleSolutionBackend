using HotelSolutionBackend.Command.Data.Context;
using HotelSolutionBackend.Command.Data.Repositories;
using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using HotelSolutionBackend.Query.Application.Abstractions;
using HotelSolutionBackend.Query.Application.Mapper;
using HotelSolutionBackend.Query.Application.Services;
using HotelSolutionBackend.Query.Data.Context;
using HotelSolutionBackend.Query.Data.QueryContext;
using HotelSolutionBackend.Query.Model.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace HotelSolutionBackend.Api
{
    public class Startup
    {
        readonly string FrontendOrigins = "_frontendOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: FrontendOrigins, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .WithHeaders("Content-Type")
                        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
                });
            });
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserAppService, UserAppService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("HotelSolutionBackend.Command.Application")));

            services.AddAutoMapper(typeof(QueryModelMapper).Assembly);
            services.AddScoped<IQueryContext, QueryContext>();

            services.AddDbContext<HotelSolutionBackendCommandContext>(options => options.UseNpgsql(Configuration.GetConnectionString("CommandDbConfig")));
            services.AddDbContext<HotelSolutionBackendContext>(options => options.UseNpgsql(Configuration.GetConnectionString("QueryDbConfig")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(FrontendOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
