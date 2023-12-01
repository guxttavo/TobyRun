using Core.Extensions;

namespace Web.Configurations.Extensions
{
    public static class CookieExtensions
    {
        public static Usuario SerializarToken(this string cookie)
        {
            var idUsuario = DecodeToken.GetId(cookie);

            var usuario = new Usuario
            {
                Id = idUsuario,
                Nome = DecodeToken.GetProperty(cookie, DecodeToken.PropertyTokenEnum.Nome),
                Email = DecodeToken.GetProperty(cookie, DecodeToken.PropertyTokenEnum.Email)
            };

            return usuario;
        }
    }
}