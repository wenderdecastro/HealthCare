using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//jwt

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateActor = true,

        // Define se o tempo de expira��o sera validado
        ValidateLifetime = true,

        // Forma de criptografia e valida a chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-healthclinic.webapi.auth.dev-senai")),

        // Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromHours(3),

        // Nome do issuer (de onde est� vindo)
        ValidIssuer = "HealthClinic",

        // Nome da audience (para onde est� indo)
        ValidAudience = "HealthClinic"
    };
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informa��es sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HealthClinic",
        Description = "Uma webAPI criada no SENAISP para realiza��o do projeto HealthClinic, projeto de avalia��o da sprint 2 API.",
        Contact = new OpenApiContact
        {
            Name = "Github",
            Url = new Uri("https://github.com/wenderdecastro")
        },

    });

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
