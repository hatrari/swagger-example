using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Items.Persistence;
using Items.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Items
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
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddDbContext<ItemsContext>(opt => opt.UseInMemoryDatabase("items"));
            services.AddSwaggerGen(swagger => {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Items APIs", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API V1");
            });
        }
    }
}
