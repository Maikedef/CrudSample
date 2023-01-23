namespace CrudSample.Domain.Entities.Empresas
{
    public record Endereco
    {
        public int Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco()
        {

        }
        public Endereco(string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
