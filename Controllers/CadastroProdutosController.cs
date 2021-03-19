using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mercado.Models;

namespace Mercado.Controllers
{
    public class CadastroProdutosController : Controller
    {
        private static List<CadastraProdutoModel> _listaCadastroProdutos = new List<CadastraProdutoModel>()
        {
            new CadastraProdutoModel(){ Id=1,Nome="Livros",Status=true},
            new CadastraProdutoModel(){ Id=2,Nome="Livros",Status=true},
            new CadastraProdutoModel(){ Id=3,Nome="Livros",Status=true},

        };
        [Authorize]
        public ActionResult CadastraProdutos()
        {
            return View( _listaCadastroProdutos);
        }
        [Authorize]
        public ActionResult Produtos()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        
        public ActionResult RecuperarCadastroProduto(int id) 
        {
           return Json(_listaCadastroProdutos.Find(x => x.Id == id));
        }
        [HttpPost]
        [Authorize]

        public ActionResult ExcluirCadastroProduto(int id)
        {
            var ret = false;
            var registroBD= _listaCadastroProdutos.Find(x => x.Id == id);//busca no banco de dados
            if (registroBD != null) //faz a remoção do item com esse if
            {
                _listaCadastroProdutos.Remove(registroBD);
                ret = true;
            
            }
            return Json(ret);
        }

        [HttpPost]
        [Authorize]

        public ActionResult SalvarCadastroProduto(CadastraProdutoModel model)
        {
            var resultado = "Ok";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "Aviso";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaCadastroProdutos.Find(x => x.Id == model.Id);//busca no banco de dados

                    if (registroBD == null) //verifica se o item não existe no banco  com esse if caso nao exista é adicionado 
                    {
                        registroBD = model;
                        registroBD.Id = _listaCadastroProdutos.Max(x => x.Id) + 1;
                        _listaCadastroProdutos.Add(registroBD);


                    }
                    else
                    {
                        
                        registroBD.Nome = model.Nome;
                        registroBD.Status = model.Status;

                    }

                }
                 catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }
            return Json (new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }
        [Authorize]

        public ActionResult ProdutosCategoria()
        {
            return View();
        }
        [Authorize]
        public ActionResult ProdutosSubCategoria()
        {
            return View();
        }
    }
}