using System.Security.Cryptography;
using System.Text;

namespace CrudSample.Application.Cryptography
{
    public class EncryptService
    {
        private readonly string _chaveAdicionalSenha;

        public EncryptService(string chaveAdicionalSenha)
        {
            _chaveAdicionalSenha = chaveAdicionalSenha;
        }
        public string Criptografar(string senha)
        {
            senha = $"{senha}{_chaveAdicionalSenha}";
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            var sha512 = SHA512.Create();
            byte[] hasByte = sha512.ComputeHash(bytes);
            return StringBytes(hasByte);
        } 

        private string StringBytes(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                var hex = bytes[i].ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
