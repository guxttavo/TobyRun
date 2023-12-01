using System.Xml.Linq;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers
{
    public class AuthenticatedController : Controller
    {
        protected Usuario UsuarioLogado { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var cookie = Request.Cookies["DataInfraAuthentication"];

            if (string.IsNullOrEmpty(cookie))
            {
                context.Result = new RedirectResult("/login");
                return;
            }

            try
            {
                var jwtCookie = DecodeToken.Handler(cookie);
                var tokenExp = jwtCookie.Claims.First(claim => claim.Type.Equals("exp")).Value;
                var ticks = long.Parse(tokenExp);
                var tokenDate = DateTimeOffset.FromUnixTimeSeconds(ticks).DateTime;

                if (tokenDate <= DateTime.UtcNow)
                {
                    Response.Cookies.Delete("DataInfraAuthentication");
                    context.Result = new RedirectResult("/login");
                    return;
                }
            }
            catch
            {
                Response.Cookies.Delete("AstraAuthentication");
                context.Result = new RedirectResult("/login");
                return;
            }

            UsuarioLogado = Configurations.Extensions.CookieExtensions.SerializarToken(cookie);
            ViewBag.UsuarioLogado = UsuarioLogado;
        }

    }
}