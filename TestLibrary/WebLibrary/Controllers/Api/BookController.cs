using Infrastructure.Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestLibrary.Domain.Services.Interface;

namespace WebLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices iBookServices)
        {
            _bookServices = iBookServices;
        }

        [HttpGet("GetBook")]
        public IActionResult GetBook(int idBook)
        {
            BookEntity result = _bookServices.GetBook(idBook);

            return Ok(result);
        }

        [HttpGet("GetAllBook")]
        public IActionResult GetAllBook()
        {
            List<BookEntity> result = _bookServices.GetAllBook();
            return Ok(result);
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int idBook)
        {
            IActionResult response;
            bool result = _bookServices.DeleteBook(idBook);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo eliminar el Libro");
            return response;
        }

        [HttpPost("InsertBook")]
        public IActionResult InsertBook(BookEntity data)
        {
            IActionResult response;
            bool result = _bookServices.InsertBook(data);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo crear el Libro");
            return response;
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(BookEntity data)
        {
            IActionResult response;
            bool result = _bookServices.UpdateBook(data);
            if (result)
                response = Ok(result);
            else
                response = BadRequest("No se pudo actualizar el Libro");
            return response;
        }
    }
}