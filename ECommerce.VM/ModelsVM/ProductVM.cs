using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.VM.ModelsVM
{
    public class ProductVM:Product
    {
        [Required(ErrorMessage ="Name Is Required..")]
        public string Name { get; set; }
        [Required(ErrorMessage ="This Field Is Required...")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage ="This Field is Required.... ")]
        public bool IsActive { get; set; }
        public DateTime ArriveDate { get; set; }

        public string _ArriveDate { get; set; }
        [Required(ErrorMessage = "This Field Is Required....")]
        public double Pricre { get; set; }
       public List<BrandVM> BrandVMs { get; set; }
       public  List<CategoryVM> CategoryVMs { get; set; }
       public List<SupplierVM> SupplierVMs { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
}