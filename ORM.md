# ORM
ORM stands for object relational mapper, and its a technology that abstracts away from having to write specific sql statements
ORM's help with translating between a programming language and a DB language

Entity Framework Core is the ORM for .NET Core, and it uses ADO.NET under the hood, but presents even more streamlined interface.

## Two Different Approaches
### DB First (aka Reverse Engineering)
We take the pre-existing db, and let EF core read the schema of the db and create C# objects out of it
We _scaffold_ the tables into our C# objects

### Code First
We take the existing C# model objects and let EF Core create tables from it
We reflect the changes in our C# model to our db through _migrations_
### In your Data Access Layer Install the following
aka run `dotnet add package package-name`
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer

### In your Application (in our case, asp.net core app)
- Microsoft.EntityFrameworkCore.Design

### Globally (so anywhere) run this
- `dotnet tool install --global dotnet-ef`
## DbContext
DbContext is essentially EFCore's dea of the db structure
In code first, we need to create our own DbContext to let EFCore know, which tables to create with thich columns, keys, constraints, etc.
However, EFCore just like ASP.NET has a lot of default behaviors, so as long as your model classes follow a 

```csharp
using Microsoft.EntityFrameworkCore;
using Models;
namespace DataAccess;
public class PokeDbContext: DbContext
{
    // Whatever set up dbcontext does in its empty constructor, do that
    public PokeDbContext():base(){}
    public PokeDbContext(DbContextOptions options):base(options){}
    public DbSet<Pokemon> Pokemons{get;set;}
    public DbSet<PokeTrainer> PokeTrainers {get;set;}
}
```
`dotnet ef migrations add initialMigration -c PokeDbContext --startup-project ../WebAPI`