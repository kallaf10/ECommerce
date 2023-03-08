using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ECommerce.BLL.Repository
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository 
    {
        ECommerceEntities ECommerceDB;
        public ProductRepository()
        {
            ECommerceDB = new ECommerceEntities();
        }
        public List<Product> GetAllInclude()
        {
            return ECommerceDB.Product.Include("Brand").ToList();
        }
    }
}
