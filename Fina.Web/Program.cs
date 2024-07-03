using Fina.Core;
using Fina.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddHttpClient(WebConfiguration.HttpClienteName,
    opcao => opcao.BaseAddress = new Uri(Configuration.BackendUrl));

await builder.Build().RunAsync();
