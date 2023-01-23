namespace CrudSample.Application.ViewsModels.Empresas
{
    public class AtualizarEmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
