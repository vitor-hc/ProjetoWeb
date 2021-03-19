using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mercado.Models;

namespace Mercado.Models
{
    public class CadastraProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Preencha todos os campos")]
        public string Nome { get; set; }
        [Required]
        public bool Status { get; set; }
       

    }
}