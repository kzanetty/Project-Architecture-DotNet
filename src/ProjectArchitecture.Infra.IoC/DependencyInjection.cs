﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Mappings;
using ProjectArchitecture.Application.Services;
using ProjectArchitecture.Application.Validators;
using ProjectArchitecture.Domain.Interfaces;
using ProjectArchitecture.Infra.Data.Context;
using ProjectArchitecture.Infra.Data.Repositories;

namespace ProjectArchitecture.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("ProjectArchitecture.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myhandlers));


            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryRequestValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(UpdateCategoryRequestValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(CreateProductRequestValidator));

            
            return services;
        }
    }
}
