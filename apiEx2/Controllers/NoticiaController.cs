using apiEx2.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly List<Noticia> noticias = new List<Noticia>();

        public NoticiaController() {
            
            
            noticias.Add(new Noticia {Autor = "Yan", Conteudo = "teste 1, teste 2, teste 3 ", Data = "03/04/2023",Id = 1,Titulo = "testando1"});
            noticias.Add(new Noticia { Autor = "João", Conteudo = "teste 2, teste 3, teste 4 ", Data = "03/03/2023", Id = 2, Titulo = "testando2" });
            noticias.Add(new Noticia { Autor = "Pedro", Conteudo = "teste 5, teste 6, teste 7 ", Data = "03/02/2023", Id = 3, Titulo = "testando3" });
        }

        [HttpGet]
        public List<Noticia> GetAll() {
            return noticias;
        }
        
        [HttpPost]
        public IActionResult Add([FromBody] Noticia noticia)
        {
            noticia.Id = noticia.Id;
            noticias.Add(noticia);
            return Ok("Noticia adicionada com sucesso");
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            if (id == null) return NotFound();

            var noticia = noticias.Where(noticia => noticia.Id.ToString().Equals(id.ToString())).FirstOrDefault();
            return Ok(noticia);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Noticia? noticia = GetNoticia(id.ToString());

            if (noticia == null) return NotFound();

            noticias.Remove(noticia);

            return Ok("noticia removida com sucesso!");
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Noticia noticia)
        {
            var editNoticia = GetNoticia(id);
            if (editNoticia == null) return NoContent();

            editNoticia.Titulo = noticia.Titulo;
            editNoticia.Autor = noticia.Autor;
            editNoticia.Data = noticia.Data;
            editNoticia.Conteudo = noticia.Conteudo.ToString();

            return Ok(editNoticia);
        }
        private Noticia? GetNoticia(string id)
        {
            return noticias.Where(noticia => noticia.Id.ToString().Equals(id.ToString())).FirstOrDefault();
        }
    }
}
