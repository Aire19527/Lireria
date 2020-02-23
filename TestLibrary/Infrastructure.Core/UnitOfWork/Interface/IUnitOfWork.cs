using Infrastructure.Core.Repository;
using Infrastructure.Entity.Entity;
using System;

namespace Infrastructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        Repository<BookEntity> BookRepository { get; }
        Repository<EditorialEntity> EditorialRepository { get; }


        new void Dispose();

        int Save();
    }
}
