using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Infraestructure;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Infraestructure;
using LibeyTechnicalTestDomain.RegionAggregate.Application;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Infraestructure;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.UbigeoAggregate.Infraestructure;
namespace LibeyTechnicalTestAPI.Middleware
{
    public static class DIExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            //LibeyUser
            services.AddTransient<ILibeyUserAggregate, LibeyUserAggregate>();
            services.AddTransient<ILibeyUserRepository, LibeyUserRepository>();

            // DocumentType
            services.AddTransient<IDocumentTypeAggregate, DocumentTypeAggregate>();
            services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();

            // Region
            services.AddTransient<IRegionAggregate, RegionAggregate>();
            services.AddTransient<IRegionRepository, RegionRepository>();

            // Province
            services.AddTransient<IProvinceAggregate, ProvinceAggregate>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();

            // Ubigeo
            services.AddTransient<IUbigeoAggregate, UbigeoAggregate>();
            services.AddTransient<IUbigeoRepository, UbigeoRepository>();

            return services;
        }
    }
}
