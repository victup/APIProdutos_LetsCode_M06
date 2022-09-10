using APIProdutos.Core.Interfaces;
using APIProdutos.Core.Services;
using APIProdutos.Filters;
using APIProdutos.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCors",
        policy =>
        {
            policy.WithOrigins("https://localhost:7236");
            policy.WithHeaders("x-victor");
            policy.AllowAnyMethod();
            //policy.WithMethods("GET", "POST");
        });
});

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<LogResultFilter>();
    options.Filters.Add<GeneralExceptionFilter>();
}
);

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<GaranteProdutoExisteActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("PolicyCors");

app.MapControllers();

app.Run();