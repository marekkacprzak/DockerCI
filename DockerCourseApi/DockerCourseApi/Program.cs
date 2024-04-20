using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/podcasts", async () =>
{
    var db = new SqlConnection("Server=tcp:database;Initial Catalog=podcasts;Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
   return (await db.QueryAsync<Podcast>("select * from Podcasts")).Select(x=>x.Title).ToList();
    return new List<string>
    {
        "Unhandled Exception Podcast",
        "Developer Weekly Podcast",
        "The Stack Overflow Podcast",
        "The Hanselminutes Podcast",
        "The .NET Rocks Podcast",
        "The Azure Podcast",
        "The AWS Podcast",
        "The Rabbit Hole Podcast",
        "The .NET Core Podcast"
    };
});

app.Run();

record Podcast(Guid Id, string Title);