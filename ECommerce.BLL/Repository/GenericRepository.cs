using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        ECommerceEntities ECommerceDB;
        public GenericRepository()
        {
                ECommerceDB =new ECommerceEntities();
        }
        public int Add(T Obj)
        {
            ECommerceDB.Set<T>().Add(Obj);
            return ECommerceDB.SaveChanges();
        }

        public int Delete(int ID)
        {
            ECommerceDB.Set<T>().Remove(GetById(ID));
            return ECommerceDB.SaveChanges();
        }

        public int Edit(int id ,T obj)
        {
           T Ent = ECommerceDB.Set<T>().Find(id);
            Ent = obj;
            ECommerceDB.Set<T>().AddOrUpdate(Ent);
           return ECommerceDB.SaveChanges();
        }

        public List<T> GetAll()
        {
            return ECommerceDB.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return ECommerceDB.Set<T>().Find(id);
        }
    }
}
