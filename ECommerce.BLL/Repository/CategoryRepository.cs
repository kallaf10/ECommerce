using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class CategoryRepository: GenericRepository<Category>,ICategoryRepository
    {
        public List<Category> GetCategoriesByname(string name)
        {
            List<Category> AllCategories= GetAll();

            List<Category> categories = AllCategories.Where(c => c.Name == name).ToList();
            return categories;
        }
    }
}
