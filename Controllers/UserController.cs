using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserStudio.Models;
using UserStudio.ViewModels;

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
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };
                
                users.Add(newUser);

                return Redirect("/User");
            }

            else
            {
                return View(addUserViewModel);
            }
        }
    }
}