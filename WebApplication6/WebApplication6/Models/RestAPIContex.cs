using System.Data.Entity;

namespace WebApplication6.Models
{
    public class RestAPIContex : DbContext
    {
        public RestAPIContex() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<WebApplication6.Models.produto> produtoes { get; set; }

        public System.Data.Entity.DbSet<WebApplication6.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<WebApplication6.Models.controleProduto> controleProdutoes { get; set; }
    }
}