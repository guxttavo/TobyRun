using System.IdentityModel.Tokens.Jwt;

namespace Core.Extensions
{
    public class DecodeToken
    {
        public enum PropertyTokenEnum
        {
            Email = 1,
            Nome = 2
        }

        public static JwtSecurityToken Handler(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            
            // método ReadToken da instância JwtSecurityTokenHandler é chamado com o token como argumento. 
            //Isso efetivamente "lê" o token e o converte em um objeto JwtSecurityToken.
            var readToken = handler.ReadToken(token) as JwtSecurityToken;

            return readToken;
        }

        public static string GetProperty(string token, PropertyTokenEnum propertyTokenEnum)
        {
            var readToken = Handler(token);

            return readToken.Claims.ToList()[(int)propertyTokenEnum].Value;
        }

        public static int GetId(string token)
        {
            var readToken = Handler(token);
            var idUsuario = readToken.Claims.ToList()[0].Value;

            if (int.TryParse(idUsuario, out int num))
                return num;

            return default;
        }

    }
}