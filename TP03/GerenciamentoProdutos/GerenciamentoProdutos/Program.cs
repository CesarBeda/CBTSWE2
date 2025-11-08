using GerenciamentoProdutos.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 1. Pegar a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// 2. Adicionar o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// 3. Adicionar os serviços do MVC
builder.Services.AddControllersWithViews();


// --- Início da Configuração de Cultura ---
// Define a cultura padrão da aplicação para "en-US" (Inglês/Invariante)
var enUsCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUsCulture),
    SupportedCultures = new[] { enUsCulture },
    SupportedUICultures = new[] { enUsCulture }
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(enUsCulture);
    options.SupportedCultures = new[] { enUsCulture };
    options.SupportedUICultures = new[] { enUsCulture };
});
// --- Fim da Configuração de Cultura ---


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// --- CORREÇÃO APLICADA AQUI ---

// 1. Habilita o uso de arquivos estáticos (CSS, JS, etc.)
// DEVE vir antes do UseRouting.
app.UseStaticFiles();

// 2. Aplica a regra de cultura (en-US) ANTES de processar as rotas
// Esta era a linha que faltava e sua ordem é crucial.
app.UseRequestLocalization(localizationOptions);

// --- FIM DA CORREÇÃO ---

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produtos}/{action=Index}/{id?}");


app.Run();