
using API_FIlmes_Entity.Data.Dtos;
using API_FIlmes_Entity.Models;
using AutoMapper;

namespace API_FIlmes_Entity.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
