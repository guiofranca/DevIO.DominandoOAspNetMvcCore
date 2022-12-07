# DevIO.DominandoOAspNetMvcCore

Implementações do curso [Dominando o ASP.NET MVC Core](https://desenvolvedor.io/curso/dominando-o-asp-net-mvc-core/)

Mais está por vir...

# Comandos que ajudam o dia a dia:

Na pasta `Curso.Data`, criar migrações:
```
dotnet ef migrations add NomeDaMigracao --context CursoDbContext --startup-project ../Curso.App
```
Para migrar, na pasta `Curso.App`
```
dotnet ef database update --context CursoDbContext
```
Para fazer rollback, na pasta `Curso.App`
```
dotnet ef database update --context CursoDbContext NomeDaMigracaoDeDestino
```
Para remover a última migração, na pasta `Curso.Data`
```
dotnet ef migrations remove --context CursoDbContext --startup-project ../Curso.App
```



Para criar migrações do Identity, na pasta `Curso.App`
```
dotnet ef migrations add Inicial --context ApplicationDbContext -o Data/Migrations
```
Para migrar, na pasta `Curso.App`
```
dotnet ef database update --context ApplicationDbContext
```
