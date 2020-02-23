using Infrastructure.Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestLibrary.Domain.Services.Interface;

namespace WebLibrary.Controllers
{
    public class EditorialController : Controller
    {
        private readonly IEditorialServices _editorialServices;
        public EditorialController(IEditorialServices iEditorialServices)
        {
            _editorialServices = iEditorialServices;
        }

        // GET: Editorial
        public IActionResult Index()
        {
            return View(_editorialServices.GetAllEditorial());
        }

        // GET: Editorial/Details/5
        public IActionResult Details(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            EditorialEntity bookEntity = _editorialServices.GetEditorial((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            response = View(bookEntity);
            return response;
        }

        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdEditorial,Name")] EditorialEntity editorialEntity)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = _editorialServices.InsertEditorial(editorialEntity);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se puudo crear la Editorial");
                    response = View(editorialEntity);
                }
            }
            else
            {
                response = View(editorialEntity);
            }

            return response;
        }

        // GET: Editorial/Edit/5
        public IActionResult Edit(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            EditorialEntity bookEntity = _editorialServices.GetEditorial((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            response = View(bookEntity);
            return response;
        }

        // POST: Editorial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdEditorial,Name")] EditorialEntity editorialEntity)
        {

            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = _editorialServices.UpdateEditorial(editorialEntity);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo editar la Editorial");
                    response = View(editorialEntity);
                }
            }
            else
            {
                response = View(editorialEntity);
            }

            return response;
        }

        // GET: Editorial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            EditorialEntity bookEntity = _editorialServices.GetEditorial((int)id);
            if (bookEntity == null)
            {
                response = NotFound();
            }
            response = View(bookEntity);
            return response;
        }

        // POST: Editorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            IActionResult response;
            bool result = _editorialServices.DeleteEditorial(id);
            if (result)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No se pudo eliminar la Editorial");
                response = RedirectToAction(nameof(Index));
            }

            return response;
        }
    }
}
