using Infrastructure.Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestLibrary.Domain.Services.Interface;

namespace WebLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialServices _editorialServices;

        public EditorialController(IEditorialServices iEditorialServices)
        {
            _editorialServices = iEditorialServices;
        }

        [HttpGet("GetEditorial")]
        public IActionResult GetEditorial(int idEdotorial)
        {
            EditorialEntity result = _editorialServices.GetEditorial(idEdotorial);

            return Ok(result);
        }

        [HttpGet("GetAllEditorial")]
        public IActionResult GetAllEditorial()
        {
            List<EditorialEntity> result = _editorialServices.GetAllEditorial();
            return Ok(result);
        }

        [HttpDelete("DeleteEditorial")]
        public IActionResult DeleteEditorial(int idEdotorial)
        {
            IActionResult response;
            bool result = _editorialServices.DeleteEditorial(idEdotorial);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo eliminar la Editorial");
            return response;
        }

        [HttpPost("InsertEditorial")]
        public IActionResult InsertEditorial(EditorialEntity data)
        {
            IActionResult response;
            bool result = _editorialServices.InsertEditorial(data);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo crear la Editorial");
            return response;
        }

        [HttpPut("UpdateEditorial")]
        public IActionResult UpdateEditorial(EditorialEntity data)
        {
            IActionResult response;
            bool result = _editorialServices.UpdateEditorial(data);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo actualizar la Editorial");
            return response;
        }
    }
}