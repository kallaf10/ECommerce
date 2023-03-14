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
    public class ProductRepository : GenericRepository<Product>,IProductRepository 
    {
        ECommerceEntities ECommerceDB;
        public ProductRepository()
        {
            ECommerceDB = new ECommerceEntities();
        }
        public List<Product> GetAllInclude()
        {
            return ECommerceDB.Product.Include("Brand").Include("Category").Include("Supplier").ToList();
        }
        public ProductVM GetProductByID(int ID)
        {
            ProductVM product = Mapper.DynamicMap<Product, ProductVM>(GetById(ID));
            return product;
        }
    }
}
