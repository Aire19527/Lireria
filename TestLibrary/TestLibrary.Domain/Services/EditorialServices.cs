using Infrastructure.Core.UnitOfWork.Interface;
using Infrastructure.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.Domain.Services.Interface;

namespace TestLibrary.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {

        public readonly IUnitOfWork _unitOfWork;

        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EditorialEntity> GetAllEditorial()
        {
            List<EditorialEntity> editorialList = _unitOfWork.EditorialRepository.GetAll(x => x.BookEntity).ToList();
            return editorialList;
        }

        public EditorialEntity GetEditorial(int idEditorial)
        {
            EditorialEntity editorial = _unitOfWork.EditorialRepository.FirstOrDefault(b => b.IdEditorial == idEditorial,
                                                                                       b => b.BookEntity);
            return editorial;
        }

        public bool InsertEditorial(EditorialEntity data)
        {
            _unitOfWork.EditorialRepository.Insert(data);
            return _unitOfWork.Save() > 0;
        }


        public bool DeleteEditorial(int idEditorial)
        {
            _unitOfWork.BookRepository.Delete(idEditorial);
            return  _unitOfWork.Save() > 0;
        }

        public bool UpdateEditorial(EditorialEntity data)
        {
            _unitOfWork.EditorialRepository.Update(data);
            bool result = _unitOfWork.Save() > 0;
            return result;
        }

    }
}
