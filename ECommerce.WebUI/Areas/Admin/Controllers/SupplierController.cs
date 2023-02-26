using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierRepository SRepository;
        public SupplierController()
        {
            SRepository = new SupplierRepository();
        }
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Add() => PartialView();
        [HttpPost]
        public ActionResult Add(SupplierVM SupplierVm)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = new Supplier { Name = SupplierVm.Name };

                SRepository.Add(supplier);

                return RedirectToAction("Index");
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult _AllSuppliers() => PartialView();
        [HttpGet]
        public JsonResult GetAllSuppliers()
        {
            List<Supplier> suppliers = SRepository.GetAll().ToList();
            List<SupplierVM> suppliersvm = suppliers.Select(Z => new SupplierVM
            {
                ID = Z.ID,
                Name = Z.Name,
            }).ToList();
            return Json(suppliersvm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _Edit(int Id)
        {
            Supplier supplier = SRepository.GetById(Id);
            SupplierVM supplierVM = new SupplierVM { ID = supplier.ID, Name = supplier.Name };

            return PartialView(supplierVM);
        }
        public ActionResult _Delete(int Id)
        {
            Supplier supplier = SRepository.GetById(Id);
            SupplierVM supplierVM = new SupplierVM { ID = supplier.ID, Name = supplier.Name };

            return PartialView(supplierVM);
        }
        public ActionResult _Details(int Id)
        {
            Supplier supplier = SRepository.GetById(Id);
            SupplierVM supplierVM = new SupplierVM { ID = supplier.ID, Name = supplier.Name };

            return PartialView(supplierVM);
        }
        public ActionResult Delete(SupplierVM supplier) 
        {
            SRepository.Delete(supplier.ID);
           return RedirectToAction("Index");
        }
        public ActionResult Edit(SupplierVM supplier) 
        {
            Supplier supp= new Supplier { ID=supplier.ID, Name=supplier.Name };
            SRepository.Edit(supp.ID,supp);
           return RedirectToAction("Index");
        }
    }
}