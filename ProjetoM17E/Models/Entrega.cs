using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoM17E.Models
{
    public class Entrega
    {
        [Key]
        public int EntregaId { get; set; }

        [ForeignKey("utilizador")]
        [Display(Name = "Uilizador")]
        [Required(ErrorMessage = "Tem de indicar o Utilizador")]
        public int utilizadorid { get; set; }
        public Utilizador utilizador { get; set; }

        [ForeignKey("produto")]
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Tem de indicar o produto")]
        public int ProdutoId { get; set; }
        public Produto produto { get; set; }

        [Display(Name = "Data de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime data_entrega { get; set; }
    }
}