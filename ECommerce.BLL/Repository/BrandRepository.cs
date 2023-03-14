using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        ECommerceEntities DB;
        public BrandRepository()
        { 
          DB= new ECommerceEntities();
        }
        public  override int Add(Brand Brand)
        {
            DB.Brand.Add(Brand);
            return DB.SaveChanges();
        }
        public int Edit(Brand Brand)
        {
            DB.Brand.AddOrUpdate(Brand);    
            return DB.SaveChanges();
        }
        public override int Delete(int ID) 
        {
            Brand Oldbrand = DB.Brand.Find(ID);
            DB.Brand.Remove(Oldbrand);
            return DB.SaveChanges();
        }
       public List<BrandVM> Browse()
        {
            return GetAll().Select(Z => Mapper.DynamicMap<Brand, BrandVM>(Z)).ToList();
        }

    }
}
