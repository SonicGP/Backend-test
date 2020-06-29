using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class controleProduto
    {
        [Key]
        public int controleProdutoId { get; set; }

        [DisplayName("Produto")]
        public int ProdutoId { get; set; }

        [DisplayName("Categoria")]
        public int categoriasId { get; set; }

        public virtual produto Produto { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}