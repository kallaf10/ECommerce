using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class ImageRepository:GenericRepository<Image>,IImageRepository
    {
        public List<Image> GetImagesByproduct(int ProductId)
        {
            List<Image> imagesByProduct = GetAll().
                Where(Z => Z.ProductID == ProductId).ToList();
            return imagesByProduct;
        }
       
    }
}
