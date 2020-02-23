using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Core.Context;
using Infrastructure.Core.UnitOfWork.Interface;
using Moq;
using TestLibrary.Domain.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Repository;
using Infrastructure.Core.Repository.Interface;
using LibraryTest;
using System.Linq;
using Infrastructure.Entity.Entity;

namespace TestLibrary.Domain.Services.Tests
{
    [TestClass()]
    public class BookServicesTests
    {
        #region Attributes

        private readonly DataContext _context;
        private IUnitOfWork _unitOfWork;
        private IBookServices _IBookServices;
        #endregion Attributes

        public BookServicesTests()
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
            _IBookServices = new BookServices(_unitOfWork);
        }

        #endregion Init


        #region Test
        [TestMethod()]
        public void GetBookTest()
        {
            var result = _IBookServices.GetBook(100);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetBookIsNullTest()
        {
            var result = _IBookServices.GetBook(100100);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void InsertBookIsTrueTest()
        {
            BookEntity data = new BookEntity
            {
                Title = "Mock_Title",
                IdEditorial = 100,
                Author = "MockAuthor",
                Cost = 100,
                Date = DateTime.Now,
                SuggestedPrice = 200
            };
            var result = _IBookServices.InsertBook(data);
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void DeleteBookIsTrueTest()
        {
            var result = _IBookServices.DeleteBook(100);
            Assert.IsTrue(result);
        }
       

        [TestMethod()]
        public void GetAllBookTest()
        {
            var result = _IBookServices.GetAllBook();
            Assert.IsTrue(result.Any());
        }
        #endregion
    }
}