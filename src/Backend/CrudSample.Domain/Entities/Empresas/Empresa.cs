using System;

namespace CrudSample.Domain.Entities.Empresas
{
    public class Empresa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string Telefone { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }
        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
