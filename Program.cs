using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.Services;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IGenerateShiftService, GenerateShiftService>();
builder.Services.AddScoped<ShiftAssistanceContext, ShiftAssistanceContext>();

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
