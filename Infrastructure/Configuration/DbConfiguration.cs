using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class DbConfiguration
    {
        public static void AddConnections(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryDbConnection")));
        }
    }
}
