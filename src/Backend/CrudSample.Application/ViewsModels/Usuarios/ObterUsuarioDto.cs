namespace CrudSample.Application.ViewsModels.Usuarios
{
    public class ObterUsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Role { get; set; }

        public ObterUsuarioDto() { }

        public ObterUsuarioDto(int id, string nome, string role)
        {
            Id = id;
            Nome = nome;
            Role = role;
        }
    }
}
