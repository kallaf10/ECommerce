using AutoMapper;
using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
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
            List<Category> AllCategories= GetAll().Where(c => c.Name == name).ToList();

        
            return AllCategories;
        }
        public List<CategoryVM> Browse()
        {
            return GetAll().Select(z=> Mapper.DynamicMap<Category,CategoryVM>(z)).ToList();
        }
    }
}
