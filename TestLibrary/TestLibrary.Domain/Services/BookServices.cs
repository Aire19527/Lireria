using Infrastructure.Core.UnitOfWork.Interface;
using Infrastructure.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.Domain.Services.Interface;

namespace TestLibrary.Domain.Services
{
    public class BookServices : IBookServices
    {
        public readonly IUnitOfWork _unitOfWork;

        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BookEntity GetBook(int idBook)
        {
            BookEntity book = _unitOfWork.BookRepository.FirstOrDefault(b => b.IdBook == idBook,
                                                                           b => b.Editorial);
            return book;
        }

        public bool InsertBook(BookEntity data)
        {
            _unitOfWork.BookRepository.Insert(data);
            return _unitOfWork.Save() > 0;
        }


        public bool DeleteBook(int idBook)
        {
            _unitOfWork.BookRepository.Delete(idBook);
            return _unitOfWork.Save() > 0;
        }

        public bool UpdateBook(BookEntity data)
        {
            _unitOfWork.BookRepository.Update(data);
            bool result = _unitOfWork.Save() > 0;
            return result;
        }

        public List<BookEntity> GetAllBook()
        {
            List<BookEntity> listBook = this._unitOfWork.BookRepository.GetAll(x => x.Editorial).ToList();
            return listBook;
        }
    }
}
