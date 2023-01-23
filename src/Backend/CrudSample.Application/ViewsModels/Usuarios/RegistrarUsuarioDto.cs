namespace CrudSample.Application.ViewsModels.Usuarios
{
    public class RegistrarUsuarioDto
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public RegistrarUsuarioDto() { }

        public RegistrarUsuarioDto(string nome, string senha, string role) 
        { 
            Nome = nome;
            Senha = senha;
            Role = role;
        }
    }
}
