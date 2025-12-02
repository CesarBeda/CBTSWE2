//Cesar Beda CB302704X

using WEB_SITE.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllersWithViews();

// --- CORREÇÃO SSL: Configuração dos Clients HTTP ignorando erros de certificado local ---

// 1. Configuração para ProdutoRepository
builder.Services.AddHttpClient<IProdutoRepository, ProdutoRepository>(client =>
{
    // Garante que usa a porta 7000 (a mesma que vimos no Swagger)
    client.BaseAddress = new Uri("https://localhost:7000/");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // Ignora validação de certificado SSL (para desenvolvimento local)
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
});

// 2. Configuração para UsuarioRepository
builder.Services.AddHttpClient<IUsuarioRepository, UsuarioRepository>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7000/");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
});

// ---------------------------------------------------------------------------------------

builder.Services.AddDistributedMemoryCache();

// Configuração da Sessão (30 minutos)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANTE: UseSession deve vir ANTES de UseAuthorization
app.UseSession();
app.UseAuthorization();

// Define a rota padrão para iniciar no Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Mantive Home/Index pois seu Login está na Home

app.Run();