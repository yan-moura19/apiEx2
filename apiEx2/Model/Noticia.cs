namespace apiEx2.Model
{
    public class Noticia
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Data { get; set; }

        public Noticia(int id,string titulo, string conteudo, string autor, string data)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            Autor = autor;
            Data = data;
        }

    }
}
