using Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectioKey = builder.Configuration["ConnectionStrings"];

var mySQLConfiguration = new MySQLConfiguration(connectioKey);
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

   
        app.UseSwagger();
        app.UseSwaggerUI();
    

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
