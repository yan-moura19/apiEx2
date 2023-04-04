using apiEx2.Data;
using apiEx2.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        


        [HttpGet]
        public IActionResult GetAll() {
            return Ok(NoticiaDB.noticias);
        }
        
        [HttpPost]
        public IActionResult Add([FromBody] Noticia noticia)
        {
            noticia.Id = noticia.Id;
            NoticiaDB.noticias.Add(noticia);
            return Ok("Noticia adicionada com sucesso");
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            if (id == null) return NotFound();

            var noticia = NoticiaDB.noticias.Where(noticia => noticia.Id.ToString().Equals(id.ToString())).FirstOrDefault();
            return Ok(noticia);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Noticia? noticia = GetNoticia(id);

            if (noticia == null) return NotFound();

            NoticiaDB.noticias.Remove(noticia);

            return Ok("noticia removida com sucesso!");
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Noticia noticia)
        {
            var editNoticia = GetNoticia(id);
            if (editNoticia == null) return NoContent();

            editNoticia.Titulo = noticia.Titulo;
            editNoticia.Autor = noticia.Autor;
            editNoticia.Data = noticia.Data;
            editNoticia.Conteudo = noticia.Conteudo.ToString();

            return Ok(editNoticia);
        }
        private Noticia? GetNoticia(int id)
        {
            return NoticiaDB.noticias.Where(noticia => noticia.Id.ToString().Equals(id.ToString())).FirstOrDefault();
        }
    }
}
