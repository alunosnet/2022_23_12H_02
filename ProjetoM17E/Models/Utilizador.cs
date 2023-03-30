using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjetoM17E.Models
{
    public class Utilizador
    {
        [Key]
        public int UtilizadorId { get; set; }

        [Required(ErrorMessage = "Indique um nome de Utilizador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Indique o perfil de utilizador")]
        public int Perfil { get; set; }

        [Display(Name = "Estado da conta")]
        public int Estado { get; set; }

        //dropdown perfil
        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }
        
    }
}