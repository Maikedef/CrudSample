using AutoMapper;
using CrudSample.Application.ViewsModels.Usuarios;
using CrudSample.Domain.Entities.Usuarios;

namespace CrudSample.Application.Services.Automapper.Usuarios
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<AutenticarUsuarioDto, Usuario>();
            CreateMap<RegistrarUsuarioDto, Usuario>();
        }
    }
}
