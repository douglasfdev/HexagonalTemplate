using HexagonalTemplate.Adapters.WebApi.Transformers;
using HexagonalTemplate.Core.Application;
using HexagonalTemplate.Infrastructure.PgSql;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugyParamatersTransformer()));
    options.SuppressAsyncSuffixInActionNames = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7200")
            .AllowAnyHeader()
            .AllowAnyMethod());

    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

});
builder.Services
    .AddPgSqlLayer(builder.Configuration)
    .AddApplicationLayer();

var app = builder.Build();

app.UseCors("AllowAll"); // Ou AllowSpecificOrigin
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();