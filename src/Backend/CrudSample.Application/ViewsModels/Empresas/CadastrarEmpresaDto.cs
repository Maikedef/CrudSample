namespace CrudSample.Application.ViewsModels.Empresas
{
    public class CadastrarEmpresaDto
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
