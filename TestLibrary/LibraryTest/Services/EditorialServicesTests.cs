using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Core.UnitOfWork.Interface;
using Infrastructure.Core.Context;
using TestLibrary.Domain.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Repository.Interface;
using Infrastructure.Core.Repository;
using LibraryTest;
using System.Linq;
using Infrastructure.Entity.Entity;

namespace TestLibrary.Domain.Services.Tests
{
    [TestClass()]
    public class EditorialServicesTests
    {


        #region Attributes

        private readonly DataContext _context;
        private IUnitOfWork _unitOfWork;
        private IEditorialServices _IEditorialServices;
        #endregion Attributes

        public EditorialServicesTests()
        {
            var services = new ServiceCollection();

            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            _context = ContextMock.Seed();
        }

        #region Init

        [TestInitialize]
        public void Init()
        {
            this._unitOfWork = new UnitOfWork(_context);
            _IEditorialServices = new EditorialServices(_unitOfWork);
        }

        #endregion Init


        [TestMethod()]
        public void GetAllEditorialTest()
        {
            var result = _IEditorialServices.GetAllEditorial();
            Assert.IsTrue(result.Any());
        }

        [TestMethod()]
        public void GetEditorialTest()
        {
            var result = _IEditorialServices.GetEditorial(100);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetEditorialIsNullTest()
        {
            var result = _IEditorialServices.GetEditorial(1000);
            Assert.IsNull(result);
        }


        [TestMethod()]
        public void InsertEditorialTest()
        {
            EditorialEntity data = new EditorialEntity
            {
                Name = "Mock"
            };

            var result = _IEditorialServices.InsertEditorial(data);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DeleteEditorialTest()
        {
            var result = _IEditorialServices.DeleteEditorial(103);
            Assert.IsTrue(result);
        }
              
    }
}