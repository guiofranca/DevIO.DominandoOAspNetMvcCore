using Curso.App.Data;
using Curso.Business.Interfaces;
using Curso.Business.Notificacoes;
using Curso.Business.Services;
using Curso.Data.Context;
using Curso.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Curso.App.Configurations;

public static class DependencyInjectionExtension
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services) {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<CursoDbContext>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IFornecedorService, FornecedorService>();

        return services;
    }

    public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration config) {
        var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddDbContext<CursoDbContext>(options => 
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}