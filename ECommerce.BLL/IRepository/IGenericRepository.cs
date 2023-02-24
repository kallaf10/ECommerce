using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
         int  Add (T Entity);
        List<T> GetAll();
        T GetById(int id);
        int Edit(int id, T Entity);
        int Delete(int ID);
    }
}
