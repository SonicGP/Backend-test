using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Categoria
    {
        [Key]
        [DisplayName("Categoria Id")]
        public int categoriasId { get; set; }

        [DisplayName("Categoria")]
        public string nome { get; set; }

        public virtual ICollection<controleProduto> ControleProdutos { get; set; }
    }
}