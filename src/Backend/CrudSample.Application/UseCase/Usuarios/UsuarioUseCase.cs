using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.ViewsModels.Usuarios;
using CrudSample.Domain.Repository.Usuarios;
using CrudSample.Domain.Entities.Usuarios;
using CrudSample.Application.Cryptography;
using CrudSample.Application.Services.Token;
using AutoMapper;

namespace CrudSample.Application.UseCase.Usuarios
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly EncryptService _encrypt;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioUseCase(
            IUsuarioRepository usuarioRepository,
            EncryptService encrypt,
            IMapper mapper,
            TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _encrypt = encrypt;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<RespostaUsuarioAutenticadoDto> AutenticarAsync(AutenticarUsuarioDto autenticarUsuarioDto)
        {

            string senhaCriptografada = _encrypt.Criptografar(autenticarUsuarioDto.Senha);
            autenticarUsuarioDto.Senha = senhaCriptografada;

            var usuario = await _usuarioRepository.AutenticarAsync(autenticarUsuarioDto.Nome, senhaCriptografada);

            if (usuario != null)
            {
                string token = _tokenService.GerarToken(usuario);
                string tokenType = _tokenService.TipoToken;
                return new RespostaUsuarioAutenticadoDto
                {
                    Token = token,
                    TokenType = tokenType
                };
            }
            return null;
        }

        public async Task<RespostaUsuarioAutenticadoDto> CadastrarAsync(RegistrarUsuarioDto registrarUsuarioDto)
        {
            string senhaCriptografada = _encrypt.Criptografar(registrarUsuarioDto.Senha);
            registrarUsuarioDto.Senha = senhaCriptografada;
            var usuario = _mapper.Map<RegistrarUsuarioDto, Usuario>(registrarUsuarioDto);
            await _usuarioRepository.CadastrarAsync(usuario);

            string token = _tokenService.GerarToken(usuario);
            string tokenType = _tokenService.TipoToken;
            return new RespostaUsuarioAutenticadoDto
            {
                Token = token,
                TokenType = tokenType
            };
        }

        public Task<bool> ContemUsuarioCadastradoAsync()
        {
            return _usuarioRepository.ContemUsuarioCadastradoAsync();
        }
    }
}
