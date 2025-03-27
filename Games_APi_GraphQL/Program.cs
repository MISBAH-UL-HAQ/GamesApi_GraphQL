using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Games_APi_GraphQL.Data;
using Games_APi_GraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/* disable swagger*/

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



// Configure CORS for your React frontend (adjust URL as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Register GraphQL services
builder.Services.AddScoped<Games_APi_GraphQL.GraphQL.Query>();
builder.Services.AddScoped<Mutation>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Games_APi_GraphQL.GraphQL.Query>()
    .AddMutationType<Mutation>();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

/* disable swagger*/

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}



app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



// Set up routing and GraphQL endpoint
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL(); // Exposes the GraphQL API endpoint
});



app.Run();
