using System.Text;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Core.Settings;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Web.Configurations
{
    public static class DependecyInjection
    {
        public static void AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var key = Encoding.ASCII.GetBytes(appSettings.TokenSettings.Chave);

            services.AddAuthentication(x =>
          {
              x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
            .AddJwtBearer(x =>
          {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(key),
                  ValidateIssuer = false,
                  ValidateAudience = false
              };
          });

            services.AddControllersWithViews();

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<Notification>();
            services.AddScoped<CryptographySettings>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IDenunciaRepository, DenunciaRepository>();
            services.AddScoped<IDenunciaService, DenunciaService>();
            // services.AddScoped<ISuporteRepository, SuporteRepository>();
        }
    }
}
