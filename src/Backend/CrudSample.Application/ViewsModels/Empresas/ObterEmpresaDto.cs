namespace CrudSample.Application.ViewsModels.Empresas
{
    public class ObterEmpresaDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
