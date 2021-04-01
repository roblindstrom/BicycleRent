
using BicycleRent.Core;
using BicycleRent.Core.Services;
using BicycleRent.Data;
using BicycleRent.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;


namespace BicycleRent.Api
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

            services.AddDbContext<BicycleRentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("BicycleRent.Data")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IBicycleService, BicycleService>();

            services.AddTransient<IBookingService, BookingService>();

            services.AddTransient<ICustomerInformationService, CustomerInformationService>();
            //services.AddTransient<ICustomer_AddressService>  
            //
            //Jag har inte skapat någon customer_addressService, får se om det behövs

            services.AddTransient<IAddressService, AddressService>();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Bicycle Rental", Version = "v1" });
            });



            services.AddAutoMapper(typeof(Startup));


            //Gör om Enums till strings i Swagger
            services
            .AddControllersWithViews()
             .AddNewtonsoftJson(options =>
                    options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            // order is vital, this *must* be called *after* AddNewtonsoftJson()
            services.AddSwaggerGenNewtonsoftSupport();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bicycle Rental V1");
            });




        }
    }
}

