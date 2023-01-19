﻿using CrudSample.Domain.Entities.Usuarios;
using CrudSample.Domain.Repository.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Infrastructure.Data.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CrudSampleDbContext _context;

        private readonly UnityOfWork _unityOfWork;

        public UsuarioRepository(CrudSampleDbContext context, UnityOfWork unityOfWork)
        {
            _context = context;
            _unityOfWork = unityOfWork;
        }
        public async Task<Usuario?> AutenticarAsync(string nome, string senha)
        {
            return  await _context.Usuarios.FirstOrDefaultAsync(x => x.Nome == nome && x.Senha == senha);
        }

        public async Task CadastrarAsync(Usuario? usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ContemAlgumUsuarioAsync()
        {
            return await _context.Usuarios.AnyAsync();
        }
    }
}
