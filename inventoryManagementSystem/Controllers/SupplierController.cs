using inventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace inventoryManagementSystem.Controllers
{
     
    public class SupplierController : Controller
    {
        sdEntities db = new sdEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySupplier()
        {
            List<supplier> list = db.suppliers.OrderByDescending(x => x.s_id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSupplier(supplier sup)
        {
            db.suppliers.Add(sup);
            db.SaveChanges();
            return RedirectToAction("DisplaySupplier");
        }
        [HttpGet]
        public ActionResult UpdateSupplier(int id)
        {
            supplier sp = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult UpdateSupplier(int id, supplier sup)
        {
            supplier sp = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
            sp.supplier_name = sup.supplier_name;
            sp.number = sup.number;
            sp.email = sup.email;
            db.SaveChanges();
            return RedirectToAction("DisplaySupplier");
        }
        [HttpGet]
        public ActionResult SupplierDetail(int id)
        {
            supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
            return View(sup);
        }

        //public ActionResult SupplierDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    else
        //    {
        //        supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
        //        return View(sup);
        //    }

        //}

        //public ActionResult SupplierDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //        // Return an error message to the user.
        //        TempData["ErrorMessage"] = "Please provide a valid supplier ID.";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
        //        return View(sup);
        //    }
        //}

        [HttpGet]
        //public ActionResult DeleteSupplier(int id)
        //{
        //    supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
        //    return View(sup);
        //}
        public ActionResult DeleteSupplier(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
            if (sup == null)
            {
                return HttpNotFound();
            }
            return View(sup);
            //supplier sup = db.suppliers.Where(x => x.s_id == id).SingleOrDefault();
            //return View(sup);
        }
        [HttpPost]
        public ActionResult DeleteSupplier(int id, supplier sup)
        {

            db.suppliers.Remove(db.suppliers.Where(x => x.s_id == id).SingleOrDefault());
            db.SaveChanges();
            return View("DisplaySupplier");
        }
    }
}