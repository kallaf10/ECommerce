using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
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
        public ActionResult _Delete()=> PartialView();

    }
}