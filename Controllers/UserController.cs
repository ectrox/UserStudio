using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserStudio.Models;

namespace UserStudio.Controllers
{
    public class UserController : Controller
    {
        static List<User> users = new List<User>();
        
        public IActionResult Index()
        {
            ViewBag.users = users;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User user, string verify)
        {
            if (user.Password == verify)
            {
                users.Add(user);
                return Redirect("/User/Index");
            }
            else
            {
                return Redirect("/User/Add");
            }
        }
    }
}