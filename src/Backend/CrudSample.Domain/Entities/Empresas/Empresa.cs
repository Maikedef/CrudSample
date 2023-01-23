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

        public Empresa()
        {
            CriadoEm = DateTime.UtcNow;
        }

        public Empresa(string nome, string cnpj, string telefone, Endereco endereco)
        {
            Nome = nome;
            Cnpj = cnpj;
            Telefone = telefone;
            Endereco = endereco;
            CriadoEm = DateTime.UtcNow;
        }

        public void Update (Empresa empresa)
        {
            Nome = empresa.Nome;
            Cnpj = empresa.Cnpj;
            Telefone = empresa.Telefone;
            AtualizadoEm = empresa.AtualizadoEm;
            EnderecoId = empresa.EnderecoId;
            Endereco = empresa.Endereco;
        }
    }
}
