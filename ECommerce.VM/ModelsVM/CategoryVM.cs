using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.VM.ModelsVM
{
    public class CategoryVM:Category
    {
        [Required(ErrorMessage ="Please Enter Category Name")]
        public string Name { get; set; }
    }
}
