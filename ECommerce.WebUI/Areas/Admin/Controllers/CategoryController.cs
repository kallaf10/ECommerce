using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Ctegory
        IGenericRepository<Category> categoryRepository;
        ICategoryRepository CatRepository;
        public CategoryController()
        {
            CatRepository = new CategoryRepository();
            categoryRepository = new GenericRepository<Category>();
        }
        public ActionResult CategoriesDetails()=> PartialView();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(CategoryVM categoryVM)
        {
            int Resp;
            Category category = new Category();
            category.Name = categoryVM.Name;
            category.Description = categoryVM.Description;
            List<Category> Cats = CatRepository.GetCategoriesByname(category.Name);
            List<Category> Cats_Desc = Cats.Where(s=>s.Description==category.Description).ToList();
            if (Cats.Count > 0&&Cats_Desc.Count>0)
            {
                ModelState.AddModelError("Name",errorMessage:"Thisss");
            }
            if (ModelState.IsValid)
            {
                
                Resp=categoryRepository.Add(category);
                if(Resp>0)
                {
                    TempData["Message"] = "Saved Successfully";
                }
                else
                    TempData["Message"] = "Please Check Data";
                return RedirectToAction("Index");
            }
            TempData["Message"]  = "0";
            return RedirectToAction("_Add");
        }
        public ActionResult Details(int id)
        {
            CategoryVM CatVM =new CategoryVM();
            Category Cat= categoryRepository.GetById(id);
            CatVM.ID = id;
            CatVM.Name = Cat.Name;
            CatVM.Description = Cat.Description;
            return PartialView(CatVM);
        }
        public ActionResult _Delete(int id)
        {
            CategoryVM CatVM = new CategoryVM();
            Category Cat = categoryRepository.GetById(id);
            CatVM.ID = id;
            CatVM.Name = Cat.Name;
            CatVM.Description = Cat.Description;
            return PartialView(CatVM);
        }
        public ActionResult Delete(int id) 
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult _Edit(int id)
        {
            Category Cat = categoryRepository.GetById(id);
            CategoryVM CatVM= new CategoryVM();
            CatVM.ID = Cat.ID;
            CatVM.Name = Cat.Name;
            CatVM.Description = Cat.Description;
            return PartialView(CatVM);
        }
        [HttpPost]
        public ActionResult Edit(CategoryVM CatVM)
        {
            if(ModelState.IsValid)
            {
                Category Cat = new Category();
                Cat.ID = CatVM.ID;
                Cat.Name = CatVM.Name;
                Cat.Description=CatVM.Description;
                categoryRepository.Edit(Cat.ID, Cat);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetAllCategories()
        {

            List<Category> Categories = categoryRepository.GetAll().ToList();
            List<CategoryVM> Cats = new List<CategoryVM>();
            foreach (var c in Categories)
            {
                CategoryVM category = new CategoryVM();

                category.ID = c.ID;
                category.Name = c.Name;
                category.Description = c.Description;
                Cats.Add(category);

            }
            return Json(Cats,JsonRequestBehavior.AllowGet);

        }
    }   
}