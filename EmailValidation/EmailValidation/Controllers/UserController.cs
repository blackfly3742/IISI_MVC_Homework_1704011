using EmailValidation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailValidation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel pageData)
        {
            if (pageData.Account == "mike@mail.com" && pageData.Password == "tree")
            {
                pageData.Message = $"您使用{pageData.Account}登入成功。";
            }
            else
            {
                pageData.Message = $"您輸入的帳號或密碼不正確。";
            }
            return View(pageData);
        }
    }
}