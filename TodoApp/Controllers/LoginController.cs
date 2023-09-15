using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="UserName,PassWord")]LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.membershipProvider.ValidateUser(model.UserName, model.PassWord)){
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("index","Todoes");
                }
            }
            ViewBag.message = "ログインに失敗しました。";
            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index","Login");
        }
    }
}