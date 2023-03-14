using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECommerce.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void CreateMap()
        {
            AutoMapper.Mapper.CreateMap<Supplier, SupplierVM>();
            AutoMapper.Mapper.CreateMap<SupplierVM, Supplier>();
            AutoMapper.Mapper.CreateMap<Brand, BrandVM>();
            AutoMapper.Mapper.CreateMap<BrandVM, Brand>();
            AutoMapper.Mapper.CreateMap<Category, CategoryVM>();
            AutoMapper.Mapper.CreateMap<CategoryVM, Category>();
            AutoMapper.Mapper.CreateMap<Product, ProductVM>();
            AutoMapper.Mapper.CreateMap<ProductVM, Product>();
            //AutoMapper.Mapper.CreateMap<ImageVM, Image>(); 
            AutoMapper.Mapper.CreateMap<Image, ImageVM>().ForMember(dest => dest.ProductID, o => o.MapFrom(z => z.ProductID)).ForMember(dest => dest.Image1, o => o.MapFrom(z => z.Image1)).
                ForMember(dest => dest.IsMain, o => o.MapFrom(z => z.IsMain))
                .ForMember(dest => dest.Description, o => o.MapFrom(z => z.Description))
                .ForMember(dest => dest.ProductID, o => o.Ignore()); ;

        }
    }
}
