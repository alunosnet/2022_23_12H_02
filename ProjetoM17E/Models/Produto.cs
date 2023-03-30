using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoM17E.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name = "Peso do Produto")]
        [Required(ErrorMessage ="Tem que indicar o peso do produto.")]
        public decimal Peso { get; set; }

        [Display(Name = "Preco do Produto")]
        [Range(1, 1000, ErrorMessage = "Custo do produto deve estar entre 0 e 1000")]
        [UIHint("Insira o preco do produto")]
        [Required(ErrorMessage = "Tem que indicar o preco do produto.")]
        public decimal Preco { get; set; }

        [Display(Name = "Tipo de embalagem")]
        [Required(ErrorMessage ="Tem que indicar o tipo de embalagem.")]
        public int Tipo { get; set; }

        [Display(Name = "Fragíl")]
        [Required(ErrorMessage ="Indique se o produto é fragil ou não.")] 
        public int Fragil { get; set; }
        
        public bool Estado { get; set; }


        public IEnumerable<System.Web.Mvc.SelectListItem> Tipos { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Fragils { get; set; }
        public Produto() 
        { 
            Estado = true;
        }
    }
}