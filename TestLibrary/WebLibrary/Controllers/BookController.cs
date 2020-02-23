using Infrastructure.Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TestLibrary.Domain.Services.Interface;

namespace WebLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IEditorialServices _editorialServices;

        public BookController(IBookServices iBookServices, IEditorialServices iEditorialServices)
        {
            _bookServices = iBookServices;
            _editorialServices = iEditorialServices;
        }

        // GET: Book
        public IActionResult Index()
        {
            List<BookEntity> reesult = _bookServices.GetAllBook();
            return View(reesult);
        }

        // GET: Book/Details/5
        public IActionResult Details(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            BookEntity bookEntity = _bookServices.GetBook((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            response = View(bookEntity);
            return response;
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["IdEditorial"] = new SelectList(_editorialServices.GetAllEditorial(), "IdEditorial", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdBook,Title,Date,Cost,SuggestedPrice,Author,IdEditorial")] BookEntity bookEntity)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = _bookServices.InsertBook(bookEntity);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo crear el Libro");
                    response = View(bookEntity);
                }
            }
            else
            {
                response = View(bookEntity);
            }

            return response;
        }

        // GET: Book/Edit/5
        public IActionResult Edit(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            BookEntity bookEntity = _bookServices.GetBook((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            ViewData["IdEditorial"] = new SelectList(_editorialServices.GetAllEditorial(), "IdEditorial", "Name", bookEntity.IdEditorial);
            response = View(bookEntity);
            return response;
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdBook,Title,Date,Cost,SuggestedPrice,Author,IdEditorial")] BookEntity bookEntity)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = _bookServices.UpdateBook(bookEntity);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo editar el Libro");
                    response = View(bookEntity);
                }
            }
            else
            {
                response = View(bookEntity);
            }
            ViewData["IdEditorial"] = new SelectList(_editorialServices.GetAllEditorial(), "IdEditorial", "Name", bookEntity.IdEditorial);
            return response;
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            BookEntity bookEntity = _bookServices.GetBook((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            response = View(bookEntity);
            return response;
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            IActionResult response;
            bool result = _bookServices.DeleteBook(id);
            if (result)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No se pudo eliminar el Libro");
                response = RedirectToAction(nameof(Index));
            }
            return response;
        }

    }
}
