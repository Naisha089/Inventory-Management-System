using inventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventoryManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        sdEntities db = new sdEntities();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayCategories()
        {
            List<catagory> list = db.catagories.OrderByDescending(x => x.c_id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateCategories()
        {

            List<string> list = db.suppliers.Select(x => x.supplier_name).ToList();
            ViewBag.SupplierName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategories(catagory cat)
        {
            db.catagories.Add(cat);
            db.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
    }


}
