using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

                var gameStoreAPIBaseUrl = builder.Configuration["GameStoreApiUrl"] ??
                throw new Exception("GameStoreApiUrl is not configured in appsettings.json or environment variables.");

builder.Services.AddHttpClient<GamesClient>(client =>
{
    client.BaseAddress = new Uri(gameStoreAPIBaseUrl);
});
builder.Services.AddHttpClient<GenresClient>(client =>
{
    client.BaseAddress = new Uri(gameStoreAPIBaseUrl);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
