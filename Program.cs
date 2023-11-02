using Microsoft.EntityFrameworkCore;
using InvoiceGeneratorAPI.Models;
using System.Drawing;
using System.Text;
using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Cors;



var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");


builder.Services.AddControllers();
builder.Services.AddDbContext<InvoiceContext>(opt =>
    opt.UseInMemoryDatabase("Invoices"));
builder.Services.AddDbContext<InvoiceTemplateContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("MyApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7184/");
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});



// UseCors

var app = builder.Build();
app.UseCors("AllowAngularOrigins");

//var app = builder.Build();
//System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();

