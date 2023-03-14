using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.IRepository
{
    public interface IImageRepository:IGenericRepository<Image>
    {
        List<Image> GetImagesByproduct(int ProductId);
    }
}
