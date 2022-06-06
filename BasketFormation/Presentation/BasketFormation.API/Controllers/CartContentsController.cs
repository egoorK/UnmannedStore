using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketFormation.API.Controllers
{
    public class CartContentsController : Controller
    {
        // GET: CartContentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartContentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartContentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartContentsController/Create
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

        // GET: CartContentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartContentsController/Edit/5
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

        // GET: CartContentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartContentsController/Delete/5
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
