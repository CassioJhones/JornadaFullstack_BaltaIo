using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

const string ConnectionString =
    @"Data Source=DESKTOP-QOQKFST;
    Database=fina;
    Integrated Security = True;
    Connect Timeout = 15;
    Encrypt=False;
    Trust Server Certificate=False;
    Application Intent = ReadWrite;
    Multi Subnet Failover=False";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(ConnectionString));


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
