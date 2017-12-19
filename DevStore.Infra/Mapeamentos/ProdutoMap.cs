using DevStore.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mapeamentos
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(c => c.Id);
            Property(c => c.Titulo).HasMaxLength(200).IsRequired();
            Property(c => c.Preco).IsRequired();
            Property(c => c.DataEntrada).IsRequired();

            HasRequired(c => c.Categoria);

        }
    }
}
