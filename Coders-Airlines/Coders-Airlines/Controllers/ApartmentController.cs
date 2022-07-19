using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coders_Airlines.Controllers
{
    public class ApartmentController : Controller
    {
        // GET: ApartmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
