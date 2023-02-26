using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.VM.ModelsVM
{
    public class SupplierVM:Supplier
    {
        [Required(ErrorMessage ="This Field is Required")]
        public string Name { get; set; }
    }
}
