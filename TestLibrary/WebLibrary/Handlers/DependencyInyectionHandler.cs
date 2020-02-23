using Infrastructure.Core.Repository;
using Infrastructure.Core.Repository.Interface;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using TestLibrary.Domain.Services;
using TestLibrary.Domain.Services.Interface;

namespace WebLibrary.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            #region Register (dependency injection)

            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();


            //// Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            //// Domain
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();


            #endregion
        }
    }
}
