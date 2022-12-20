using Curso.App.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbConfiguration(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.ResolveDependencies();

var app = builder.Build();

app.Configure();

app.Run();
