using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Repositories;

namespace ETicaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
           
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");


            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection")));

            //services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddScoped<IProductReadRepository, ProductReadRepository>();
            //services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            
        }
    }
}
