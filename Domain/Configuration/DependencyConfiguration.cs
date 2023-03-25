using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
