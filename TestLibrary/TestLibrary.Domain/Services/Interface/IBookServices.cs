using Infrastructure.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Domain.Services.Interface
{
    public interface IBookServices
    {
        BookEntity GetBook(int idBook);
        bool InsertBook(BookEntity data);
        bool DeleteBook(int IdBook);
        bool UpdateBook(BookEntity data);
        List<BookEntity> GetAllBook();
    }
}
