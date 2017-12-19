using DevStore.Domain.Modelos;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Infra.Mapeamentos
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            HasKey(x => x.Id);
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
        }
    }
}
