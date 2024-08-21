using API_FIlmes_Entity.Data;
using API_FIlmes_Entity.Data.Dtos;
using API_FIlmes_Entity.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_FIlmes_Entity.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmesPorId),
            new { id = filme.Id },
            filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualiaFilme(int id, [FromBody]  UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id); if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualiaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch )
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id); 
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map <UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar)){
            return ValidationProblem();
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
      var filme = _context.Filmes.FirstOrDefault(
     filme => filme.Id == id); if (filme == null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}
