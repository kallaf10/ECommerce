using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        IProductRepository ProductRepo;
        IBrandRepository brandRepository;
        ICategoryRepository categoryRepository;
        ISupplierRepository supplierRepository;
        public ProductController()
        {
            ProductRepo=new ProductRepository();
            brandRepository=new BrandRepository();
            categoryRepository=new CategoryRepository();
            supplierRepository=new SupplierRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsForm(int? id , string trigger)
        {
            List<Brand> brands = brandRepository.GetAll();
            List<Supplier> suppliers = supplierRepository.GetAll();
            List<Category> categories = categoryRepository.GetAll();
            if (id == 0||id==null)
            {
                ViewBag.FormType = "Add";

                ProductVM productVM = new ProductVM
                {
                    BrandVMs = brands.Select(s => new BrandVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Description = s.Description,
                    }).ToList(),
                    SupplierVMs = suppliers.Select(s => new SupplierVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                    }).ToList(),
                    CategoryVMs = categories.Select(c => new CategoryVM
                    {
                        ID = c.ID,
                        Name = c.Name,
                        Description = c.Description,

                    }).ToList()
                };
                return PartialView(productVM);
            }
            else if (id != 0&& trigger=="Edit")
            {
               ViewBag.FormType = "Edit";
               Product product= ProductRepo.GetAll().Where(s=>s.ID==id).FirstOrDefault();

                ProductVM productVM = new ProductVM {
                    ID = product.ID,
                    Name = product.Name,
                    Description = product.Description,
                    ShortDescription = product.ShortDescription,
                    IsActive = product.IsActive,
                    ArriveDate = product.ArriveDate,
                    Pricre = product.Pricre,
                    CategoryID = product.CategoryID,
                    BrandID = product.BrandID,
                    SupplierID = product.SupplierID,
                    BrandVMs = brands.Select(s => new BrandVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Description = s.Description,
                    }).ToList(),
                    SupplierVMs = suppliers.Select(s => new SupplierVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                    }).ToList(),
                    CategoryVMs = categories.Select(c => new CategoryVM
                    {
                        ID = c.ID,
                        Name = c.Name,
                        Description = c.Description,

                    }).ToList()
               };
                return PartialView(productVM);
            }
            else if (id != 0&& trigger=="Details")
            {
                ViewBag.FormType = "Details";
                Product product = ProductRepo.GetAll().Where(s => s.ID == id).FirstOrDefault();
                ProductVM productVM = new ProductVM
                {
                    ID = product.ID,
                    Name = product.Name,
                    Description = product.Description,
                    ShortDescription = product.ShortDescription,
                    IsActive = product.IsActive,
                    _ArriveDate = product.ArriveDate.ToString(),
                    Pricre = product.Pricre,
                    CategoryID = product.CategoryID,
                    BrandID = product.BrandID,
                    SupplierID = product.SupplierID,
                    BrandVMs = brands.Select(s => new BrandVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Description = s.Description,
                    }).ToList(),
                    SupplierVMs = suppliers.Select(s => new SupplierVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                    }).ToList(),
                    CategoryVMs = categories.Select(c => new CategoryVM
                    {
                        ID = c.ID,
                        Name = c.Name,
                        Description = c.Description,

                    }).ToList()
                };
                return PartialView(productVM);
            }

            return PartialView();
        }
        public ActionResult AllProducts()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostProduct(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                    Product product = new Product
                    {
                        ID = productVM.ID,
                        Name = productVM.Name,
                        Description = productVM.Description,
                        ShortDescription = productVM.ShortDescription,
                        IsActive = productVM.IsActive,
                        ArriveDate = productVM.ArriveDate,
                        BrandID = productVM.BrandID,
                        SupplierID = productVM.SupplierID,
                        CategoryID = productVM.CategoryID,
                        Pricre = productVM.Pricre
                    };
                if (productVM.ID == 0)
                {
                    ProductRepo.Add(product);
                    return Json(new { Done = true, Message = "Added" },JsonRequestBehavior.AllowGet);

                }
                else
                {
                    ProductRepo.Edit(product.ID,product);
                    return Json(new {Done=true, Message="Edited"}, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Message = "Erorr" }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetAllProducts()
        {

            List<ProductVM> productVMs = ProductRepo.GetAll().Select( Z=> new ProductVM
            {
                ID = Z.ID,
                Name = Z.Name,
                Description = Z.Description,
                ShortDescription = Z.ShortDescription,
                IsActive = Z.IsActive,
                _ArriveDate = Z.ArriveDate.ToString(),
                Pricre = Z.Pricre,
                CategoryID = Z.CategoryID,
                BrandID = Z.BrandID,
                SupplierID = Z.SupplierID,
                BrandName=Z.Brand.Name,
                CategoryName=Z.Category.Name,
                SupplierName=Z.Supplier.Name
            }).ToList();

            return Json(productVMs,JsonRequestBehavior.AllowGet);
        }
      public ActionResult Delete(int id)
        {
            ProductRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}