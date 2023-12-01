using System.Security.Cryptography;
using System.Text;

namespace Core.Configuration
{
    public static class Criptografia
    {
        public static string Cryptograph(this string senha)
        {
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));
            var sbString = new StringBuilder();

            foreach (var t in data)
            {
                sbString.Append(t.ToString("x2"));
            }

            return sbString.ToString();
        }
    }
}