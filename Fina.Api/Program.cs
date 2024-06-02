using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
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

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(ConnectionString));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

WebApplication app = builder.Build();

app.MapGet("/", (GetCategoryByIdRequest request, ICategoryHandler handler)
    => handler.GetByIdAsync(request));
app.Run();
