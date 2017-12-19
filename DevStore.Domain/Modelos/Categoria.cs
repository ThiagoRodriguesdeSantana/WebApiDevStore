namespace DevStore.Domain.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}