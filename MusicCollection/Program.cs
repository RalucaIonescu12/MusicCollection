using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using MusicCollection.Helpers.Extensions;
using DAL.Repositories.AccountRepository;
using DAL.Repositories.SongRepository;
using MusicCollection.Services.AccountService;
using MusicCollection.Services.SongService;
using MusicLibrary.Helpers;

var allowOrigins = "_allowOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddUtils();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

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
            .AllowAnyHeader()
            .AllowCredentials()
            ;
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
