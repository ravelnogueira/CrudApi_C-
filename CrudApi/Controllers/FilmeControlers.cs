using Microsoft.AspNetCore.Mvc;
using AluraAPI.Models;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using AluraAPI.Data;
using AutoMapper;
using AluraAPI.Data.Dtos;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilme filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id}, filme);
        }
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{ID}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme obj= _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(obj==null)
            {
                return NotFound();
            } 
            return Ok(obj);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id,
            [FromBody] UpdateFilme filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
