using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Data.SqlClient;
using NexoAPP.Services;
using System.Data;


namespace NexoAPP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IDbConnection>(options =>
            {
                var connect = builder.Configuration.GetConnectionString("SqlConnection");
                return new SqlConnection(connect);
                
            });


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoService>();            
            builder.Services.AddSingleton<NexoAPP.Services.CarritoService>();






            await builder.Build().RunAsync();

            

        }
    }
}
