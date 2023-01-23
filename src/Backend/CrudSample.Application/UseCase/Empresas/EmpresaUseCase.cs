using AutoMapper;
using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.ViewsModels.Empresas;
using CrudSample.Domain.Entities.Empresas;
using CrudSample.Domain.Repository.Empresas;

namespace CrudSample.Application.UseCase.Empresas
{
    public class EmpresaUseCase : IEmpresaUseCase
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaUseCase(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task AtualizarAsync(AtualizarEmpresaDto atualizarEmpresaDto)
        {
            var emp = await _empresaRepository.FiltrarPorIdAsync(atualizarEmpresaDto.Id);

            if(emp != null)
            {
                var empresa = _mapper.Map<Empresa>(atualizarEmpresaDto);
                emp.Update(empresa);
                await _empresaRepository.AtualizarAsync(empresa);
            }
        }

        public async Task CadastrarAsync(CadastrarEmpresaDto cadastrarEmpresaDto)
        {
            var empresa = _mapper.Map<Empresa>(cadastrarEmpresaDto);
            await _empresaRepository.CadastrarAsync(empresa);
        }

        public async Task DeletarAsync(int id)
        {
            var empresa = await _empresaRepository.FiltrarPorIdAsync(id);
            await _empresaRepository.DeletarAsync(empresa);
        }

        public async Task<ObterEmpresaDto> FiltrarPorIdAsync(int id)
        {
            var empresa = await _empresaRepository.FiltrarPorIdAsync(id);
            var empresaDto = _mapper.Map<ObterEmpresaDto>(empresa);
            return empresaDto;
        }

        public async Task<List<ObterEmpresaDto>> FiltrarPorNomeAsync(string nome)
        {
            var empresas = await _empresaRepository.FiltrarPorNomeAsync(nome);
            var empresasDto = _mapper.Map<List<ObterEmpresaDto>>(empresas);
            return empresasDto;
        }
    }
}
