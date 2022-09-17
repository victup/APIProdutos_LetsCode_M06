using APIProdutos.Core.Interfaces;
using APIProdutos.Core.Services;
using APIProdutos.Filters;
using APIProdutos.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

var key = Encoding.ASCII.GetBytes(builder.Configuration["secretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = "APIClientes.com",
            ValidateAudience = true,
            ValidAudience = "APIProdutos.com"
        };
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("PolicyCors");

app.MapControllers();

app.Run();