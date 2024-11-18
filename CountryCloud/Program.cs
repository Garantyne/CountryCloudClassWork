using CountryCloud.db;
using CountryCloud.db.repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddTransient<ICountryRepository, PostgresCountryDb>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/api-ping", () => "ping");
app.MapGet("/", () => "server is running");
app.MapControllers();


app.Run();
