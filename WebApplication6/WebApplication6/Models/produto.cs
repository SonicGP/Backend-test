using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class produto
    {
        [Key]
        [DisplayName("Produto Id")]
        public int ProdutoId { get; set; }

        [DisplayName("Produto")]
        public string nome { get; set; }

        [DisplayName("Preço")]
        public string preco { get; set; }

        //public virtual ICollection<categorias> Categorias { get; set; }

        public virtual ICollection<controleProduto> ControleProdutos { get; set; }
    }
}
