namespace CrudSample.Domain.Entities.Usuarios
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }

        public void AlterarPermissao(string role)
        {
            Role = role;
        }
    }
}
