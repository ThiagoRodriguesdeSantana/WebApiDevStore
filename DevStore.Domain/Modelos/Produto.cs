using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Modelos
{
    public class Produto
    {
        public Produto()
        {
            this.DataEntrada = DateTime.Now;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataEntrada { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}
