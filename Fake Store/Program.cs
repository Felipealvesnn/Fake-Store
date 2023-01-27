using Fake_Store_Data.Repository;
using Fake_Store_Domain.Interfaces;
using System.Configuration;
using System;
using Fake_Store_Data.DataSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Fake_Store_Data.Identity;
using ReflectionIT.Mvc.Paging;
using Fake_Store_Aplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// injeções de dependencia
builder.Services.AddTransient<IProdutosRepository, ProdutoRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<IAuthenticate, AuthenticateService>();


builder.Services.AddDbContext<DbSet>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseSqlServer(builder.Configuration.GetConnectionString("FakeStoreconeccaoDB"),
        b => b.MigrationsAssembly(typeof(DbSet).Assembly.FullName));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// iniciar Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DbSet>()
            .AddDefaultTokenProviders();


builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp)); // carrinho instaciado e iniciado na sessao

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        politica =>
        {
            politica.RequireRole("Admin");
        });
});


builder.Services.AddPaging(options => {
    options.ViewName = "Bootstrap5";
    options.PageParameterName = "pageindex";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
CriarPerfisUsuarios(app);
//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); //´para ter uma sessão 
//app.UseMvc();




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedRole();
        service.SeedUser();
    }
}