using Blazored.LocalStorage;
using IntercambioLibros;
using IntercambioLibros.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDownloadFile;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Servicios esenciales
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorDownloadFile();
builder.Services.AddBlazoredLocalStorage();

// Servicios personalizados
builder.Services.AddScoped<ServicioUsuarios>(); // ✅ Usa LocalStorage → Scoped
builder.Services.AddScoped<ServicioLibros>();   // ✅ Usa LocalStorage → Scoped
builder.Services.AddScoped<ServicioSolicitudes>(); // ✅ Si guarda datos también

// Servicios que no dependen de LocalStorage pueden ser Singleton
builder.Services.AddSingleton<SesionService>();
// ✅ CORRECTO: ya no usa una función personalizada
builder.Services.AddScoped<ServicioNotificaciones>();
builder.Services.AddSingleton<ReconocimientoFacialService>();
builder.Services.AddScoped<ServicioReseñas>();
await builder.Build().RunAsync();
