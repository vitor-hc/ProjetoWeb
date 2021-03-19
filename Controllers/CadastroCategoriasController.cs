using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercado.Controllers
{
    public class CadastroCategoriasController : Controller
    {
       [Authorize]
        public ActionResult CadastrarCategoria()
        {
            return View();
        }
        [Authorize]
        public ActionResult CadastrarSubCategoria()
        {
            return View();
        }
        [Authorize]
        public ActionResult GerenciarCategoria()
        {
            return View();
        }
        [Authorize]
        public ActionResult GerenciarSubCategoria()
        {
            return View();
        }
    }
}