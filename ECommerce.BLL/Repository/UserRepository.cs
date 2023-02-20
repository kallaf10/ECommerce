using ECommerce.BLL.IRepository;
using ECommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.VM.ModelsVM;
using System.Threading.Tasks;

namespace ECommerce.BLL.Repository
{
    public class UserRepository : IUserRepository
    {
        ECommerceEntities ECommerceDB;
        public UserRepository()
        {
                ECommerceDB= new ECommerceEntities();
        }
        
        public LogInVM LogingIn(LogInVM signin )
        {
            LogInVM logIn = new LogInVM();  
            User SigendInUser = ECommerceDB.User.Single(s => s.Username == signin.Username);

            if ( SigendInUser == null ) 
            {
                throw new Exception("Not Found");
            }
            else if(signin.Password!=SigendInUser.Password)
            {
                throw new Exception("Password Error");
            }
            logIn.Username = SigendInUser.Username;
            logIn.Password = SigendInUser.Password;
            logIn.Email = SigendInUser.Email;
            logIn.RoleID = SigendInUser.RoleID;
            logIn.Description = SigendInUser.Description;
            logIn.Name = SigendInUser.Name;
            logIn.ID = SigendInUser.ID;
            return logIn;
        }
    }
}
