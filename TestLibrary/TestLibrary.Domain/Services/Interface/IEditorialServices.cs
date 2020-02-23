using Infrastructure.Entity.Entity;
using System.Collections.Generic;

namespace TestLibrary.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        List<EditorialEntity> GetAllEditorial();

        EditorialEntity GetEditorial(int idEditorial);

        bool InsertEditorial(EditorialEntity data);

        bool DeleteEditorial(int idEditorial);

        bool UpdateEditorial(EditorialEntity data);
    }
}
