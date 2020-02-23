using Infrastructure.Core.Context;
using Infrastructure.Core.Repository;
using Infrastructure.Core.UnitOfWork.Interface;
using Infrastructure.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes
        private readonly DataContext _context;
        private bool disposed = false;
        #endregion

        #region builder
        public UnitOfWork(DataContext context)
        {
            // var serviceScope = serv.CreateScope();
            //this._context = new DataContext(serviceScope.ServiceProvider.GetRequiredService<DbContextOptions<DataContext>>());
            this._context = context;
        }
        #endregion

        #region properties
        Repository<BookEntity> bookRepository;
        Repository<EditorialEntity> editorialRepository;

        #endregion

        #region Members
        public Repository<BookEntity> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new Repository<BookEntity>(_context);

                return bookRepository;
            }
        }

        public Repository<EditorialEntity> EditorialRepository
        {
            get
            {
                if (this.editorialRepository == null)
                    this.editorialRepository = new Repository<EditorialEntity>(_context);

                return editorialRepository;
            }
        }

        #endregion


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save() => _context.SaveChanges();
    }
}
