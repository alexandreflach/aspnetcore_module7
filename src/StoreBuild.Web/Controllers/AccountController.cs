using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreBuild.Domain;
using StoreBuild.Domain.Account;
using StoreBuild.Domain.Dtos;
using StoreBuild.Domain.Products;
using StoreBuild.Web.Models;
using StoreBuild.Web.ViewsModels;

namespace StoreBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel account)
        {
            var result = _authentication.Authenticate(account.Login, account.Password).Result;
            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(account);
            }
        }
    }
}
