using ECommerce.BLL.IRepository;
using ECommerce.BLL.Repository;
using ECommerce.VM.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/User
        IUserRepository userRepository = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn(LogInVM logInM) 
        {

            if (ModelState.IsValid)
            {
                LogInVM log_InVM = userRepository.LogingIn(logInM);
                return View("Dashboard", log_InVM);
            }
            return RedirectToAction("Index","Users");

        }
    }
}