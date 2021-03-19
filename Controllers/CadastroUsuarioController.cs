using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercado.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }
        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }
        [Authorize]
        public ActionResult CadastrarNovoUsuario()
        {
            return View();
        }
    }
}