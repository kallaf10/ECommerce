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
    public class SupplierRepository:GenericRepository<Supplier>,ISupplierRepository
    {
        public List<SupplierVM> Browse()
        {
            return GetAll().Select(x => Mapper.DynamicMap<Supplier,SupplierVM>(x)).ToList();
        }
    }
}
