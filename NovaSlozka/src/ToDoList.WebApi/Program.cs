var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Ahoj!");
app.MapGet("/ahojSvete", () => "Ahoj světě!");

app.Run();
