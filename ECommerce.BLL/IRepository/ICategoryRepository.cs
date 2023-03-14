using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.IRepository
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        List<Category> GetCategoriesByname(string name);
        List<CategoryVM> Browse();
    }
}
