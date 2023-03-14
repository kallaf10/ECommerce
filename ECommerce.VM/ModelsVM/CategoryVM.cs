using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.VM.ModelsVM
{
    public class CategoryVM:Category
    {
        [Required(ErrorMessage ="Please Enter Category Name")]
        //[Remote("nameisalreadyexist ", "Add", HttpMethod = "POST", ErrorMessage = "Name already exists in database.")]
        public string Name { get; set; }
       
    }
}
