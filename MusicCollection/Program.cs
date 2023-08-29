using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;

var allowOrigins = "_allowOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MusicCollectionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//cors

builder.Services.AddCors(options => {
    options.AddPolicy(name: allowOrigins,
        builder => {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseEndpoints(endpoints =>
//{ endpoints.MapControllers(); });

app.UseHttpsRedirection();

app.UseCors(allowOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
