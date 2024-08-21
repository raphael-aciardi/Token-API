using API_FIlmes_Entity.Data.Dtos;
using API_FIlmes_Entity.Models;
using AutoMapper;

namespace API_FIlmes_Entity.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() 
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<Usuario, ReadUsuarioDto>();
    }
}
