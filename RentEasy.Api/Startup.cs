using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using RentEasy.Infra.Contexts;
using RentEasy.Infra.Repositories;

namespace RentEasy.Api
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

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentEasy.Api", Version = "v1" });
            });

            services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Database"));
            // services.AddDbContext<Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<IHouseRepository, HouseRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();

            services.AddTransient<HouseHandler, HouseHandler>();
            services.AddTransient<TenantHandler, TenantHandler>();
            services.AddTransient<ProfileHandler, ProfileHandler>();
            services.AddTransient<PhotoHandler, PhotoHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentEasy.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
