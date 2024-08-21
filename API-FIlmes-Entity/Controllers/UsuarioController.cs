using API_FIlmes_Entity.Data;
using API_FIlmes_Entity.Data.Dtos;
using API_FIlmes_Entity.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace API_FIlmes_Entity.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public UsuarioController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarUsuario([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaUsuarioPorId),
    new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaUsuarioPorId(int id)
    {
        var usuario = _context.Usuario
            .FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }
        var usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
        return Ok(usuarioDto);
    }

}

