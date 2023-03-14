using ECommerce.DAL;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.IRepository
{
    public interface IBrandRepository: IGenericRepository<Brand>
    {
        List<BrandVM> Browse();
           int Edit(Brand brand); 
    }
}
