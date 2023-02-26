using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        IBrandRepository brandRepository;
        public BrandController()
        {
            brandRepository=new BrandRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult  AllBrands()=> PartialView();
        public ActionResult _Add() => PartialView();
        [HttpGet]
        public JsonResult GetAllBrandts()
        {
            List<Brand> brands = brandRepository.GetAll().ToList();
            List<BrandVM> brandsVM = brands.Select(Z => new BrandVM
            {
                ID = Z.ID,
                Name = Z.Name,
                Description = Z.Description,
                Image = Z.Image
            }).ToList();
            return Json(brandsVM, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _Edit(int ID)
        {
            Brand brand= brandRepository.GetById(ID);
            BrandVM brandVM= new BrandVM{ 
              ID= brand.ID,
              Name = brand.Name,
              Description = brand.Description,
              Image = brand.Image
            };
            return PartialView(brandVM);
        }
        public ActionResult Add(BrandVM brand,HttpPostedFileBase fileBase)
        {
            if(fileBase ==null)
            {
                ModelState.AddModelError("Image", "Image Is Required");
            }
            if(ModelState.IsValid)
            {
                Brand newBrand = new Brand();

                newBrand.Name = brand.Name; newBrand.Description = brand.Description;
               
                brandRepository.Add(newBrand);
                Brand brandt = brandRepository.GetAll().Last();               
                
                string Imgpath = "";
                Imgpath = "F:/Projects/Internship/ECommerce/ECommerce.WebUI/Attatchments/BrandTable/Images/" + brandt.ID + "." + fileBase.ContentType.Split('/')[1];
                fileBase.SaveAs(Imgpath);
                var ImgPathSplit = Imgpath.Split('/').ToList();
                 brandt.Image = ImgPathSplit[8];
                brandRepository.Edit(brandt);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(BrandVM brandVM, HttpPostedFileBase fileBase) 
        {
            if (ModelState.IsValid)
            {
                Brand newBrand = brandRepository.GetById(brandVM.ID);
                if (fileBase == null)
                {
                    newBrand.ID = brandVM.ID;
                    newBrand.Name = brandVM.Name;
                    newBrand.Description = brandVM.Description;
                }
                else
                {
                    newBrand.ID = brandVM.ID;
                    newBrand.Name = brandVM.Name;
                    newBrand.Description = brandVM.Description;
                    string Imgpath = "";
                    Imgpath = "F:/Projects/Internship/ECommerce/ECommerce.WebUI/Attatchments/BrandTable/Images/" + newBrand.ID + "." + fileBase.ContentType.Split('/')[1];
                    fileBase.SaveAs(Imgpath);
                    var ImgPathSplit = Imgpath.Split('/').ToList();
                    newBrand.Image = ImgPathSplit[8];
                }
                brandRepository.Edit(newBrand);
            }
            return RedirectToAction("Index");
        }
        public ActionResult _Details(int id) 
        {
            Brand brand = brandRepository.GetById(id);
            BrandVM brandVM = new BrandVM
            {
                ID = brand.ID,
                Name = brand.Name,
                Description = brand.Description,
                Image = brand.Image
            };
            return PartialView(brandVM);
        }
        public ActionResult _Delete(int ID)
        {
            Brand brand = brandRepository.GetById(ID);
            BrandVM brandVM = new BrandVM
            {
                ID = brand.ID,
                Name = brand.Name,
                Description = brand.Description,
                Image = brand.Image
            };
            return PartialView(brandVM);
        }
        public ActionResult Delete(BrandVM brandVM)
        {
            Brand brnd= brandRepository.GetById(brandVM.ID);
            string file="F:/Projects/Internship/ECommerce/ECommerce.WebUI/Attatchments/BrandTable/Images/"+brnd.Image;
            brandRepository.Delete(brandVM.ID);
            FileInfo fileInfo= new FileInfo(file);
            if(fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            return RedirectToAction("Index");
        }
    }
}