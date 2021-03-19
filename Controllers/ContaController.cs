using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mercado.Controllers
{
    public class ContaController : Controller
    {
       [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl) 
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var localizou = UsuarioModel.ValidarUsuario(login.Usuario,login.Senha);
            if (localizou)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembraMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    RedirectToAction("Index","Home");

                }

            }
            else
            {
                ModelState.AddModelError("", "Login Inválido");
            }

            return View(login);
        
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logoff() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}