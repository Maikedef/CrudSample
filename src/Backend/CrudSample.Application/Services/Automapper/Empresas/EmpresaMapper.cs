using AutoMapper;
using CrudSample.Application.ViewsModels.Empresas;
using CrudSample.Domain.Entities.Empresas;

namespace CrudSample.Application.Services.Automapper.Empresas
{
    public class EmpresaMapper : Profile
    {
        public EmpresaMapper()
        {
            CreateMap<CadastrarEmpresaDto, Empresa>();
            CreateMap<EnderecoDto, Endereco>().ReverseMap();
            CreateMap<AtualizarEmpresaDto, Empresa>();
            CreateMap<Empresa, ObterEmpresaDto>();
        }
    }
}
