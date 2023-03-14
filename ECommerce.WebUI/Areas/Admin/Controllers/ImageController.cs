using AutoMapper;
using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Mvc;
using Image = ECommerce.DAL.Image;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        // GET: Admin/Image
        IImageRepository imageRepository;
        public ImageController()
        {
            imageRepository = new ImageRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductImages(int ProductID)
        {
            return Json(imageRepository.GetImagesByproduct(ProductID),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult ImageView(int id)
        {
            ViewBag.ProductID=id;
            return PartialView();
        }
        public JsonResult PostProductImage(ImageVM NewImage, HttpPostedFileBase fileBase)
        {
            if(ModelState.IsValid)
            {
                if(fileBase==null)
                {
                    ModelState.AddModelError("Image1", "Image Is Required");
                    return Json(new { action = "Error", Message = "Please Select an Image" });
                }
                Image image = new Image
                {
                    Description = NewImage.Description,
                    ID = NewImage.ID,
                    IsMain = NewImage.IsMain,
                    Image1 = NewImage.Image1,
                    ProductID = NewImage.ProductID
                };
                List<Image> ImagesOfProduct = imageRepository.GetImagesByproduct(image.ProductID);
                Image MainImage= ImagesOfProduct.Where(s=>s.IsMain==true&&s.ProductID==NewImage.ProductID).FirstOrDefault();
                if(MainImage!=null && image.IsMain==true) 
                {
                    MainImage.IsMain= false;
                    imageRepository.Edit(MainImage.ID, MainImage);
                }
                imageRepository.Add(image);
                ImagesOfProduct = imageRepository.GetImagesByproduct(image.ProductID);
                Image LastImage = ImagesOfProduct.Last();
                string Imagepath = "F:/Projects/Internship/ECommerce/ECommerce.WebUI/Attatchments/ProductImagesTable/Images/"+LastImage.ID+"."+ fileBase.ContentType.Split('/')[1];
                fileBase.SaveAs(Imagepath);
                var ImgPathSplit = Imagepath.Split('/').ToList();
                LastImage.Image1 = ImgPathSplit[8];
                imageRepository.Edit(LastImage.ID, LastImage);
                return Json(new { action = "Success",
                    Message = "Image Saved and Assigned To Product Successfully" });
            }
            else
            return  Json(new {action="Error",Message ="Error Saving Image"});
        }
        public ActionResult ImagesOfProduct() => PartialView();
        public JsonResult ImgOfProduct(int id)
        {
            List<ImageVM> imageVMs = imageRepository.GetImagesByproduct(id).
            Select(Z => Mapper.Map<Image, ImageVM>(Z)).ToList();

            return Json(imageVMs,JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangePhotoStatus(int id)
        {
            Image image = imageRepository.GetById(id);
            List<Image> images = imageRepository.GetImagesByproduct(image.ProductID);
            if(image.IsMain==true)
            {
                return Json(new
                {
                    action = "Failed",
                    Message = "Select The New Main " +
                    "Image and will Changed Automatically as this " +
                    "Image is already the main " +
                    "one",
                    productID= image.ProductID,
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Image CurrentMainImage = images.Where(Z => Z.IsMain == true).FirstOrDefault();
                if(CurrentMainImage != null)
                {
                    CurrentMainImage.IsMain = false;
                    image.IsMain= true;
                    imageRepository.Edit(image.ID, image);
                    imageRepository.Edit(CurrentMainImage.ID, CurrentMainImage);
                }
                else
                {
                    image.IsMain = true;
                    imageRepository.Edit(image.ID, image);
                }
            }
            return Json(new
            {
                action= "Success",Message="Image now is Main",
                productID = image.ProductID,
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteImage(int id)
        {
            Image image = imageRepository.GetById(id);
            if(image != null && image.IsMain == false)
            {
                string file = "F:/Projects/Internship/ECommerce/ECommerce.WebUI/Attatchments/ProductImagesTable/Images/" + image.Image1;
                imageRepository.Delete(image.ID);
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                return Json(new
                {
                    action = "Success",
                    Message = "Image Deleted Successfully" +
                    ""
                });
            }
     return Json(new
                {
                    action = "Fail",
                    Message = "This Image Is Main So Can't Delete It " +
                         "You Must Select another Image To Be main " +
                         "Then delet this Image"
                });

        }
    }
}