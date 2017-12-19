using DevStore.Domain.Modelos;
using DevStore.Infra.Mapeamentos;
using System.Data.Entity;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContext : DbContext
    {

        public DevStoreDataContext()
            : base("Server = localhost; Database=DevStore; User Id = sa; password= sap@1234")
        {
            //Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Produto> Produto{ get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            base.Seed(context);
        }
    }
}
