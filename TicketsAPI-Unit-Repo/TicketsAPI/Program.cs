using Microsoft.EntityFrameworkCore;
using TicketsAPI.Data;
using TicketsAPI.Data.Unit;
using TicketsAPI.Middleware;
using TicketsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicketContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TicketContext")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITicketService, TicketService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();