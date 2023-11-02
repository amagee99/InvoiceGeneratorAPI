using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;          
using Microsoft.Extensions.Configuration;   
using InvoiceGeneratorAPI.Models;
using Microsoft.AspNetCore.Cors;


namespace InvoiceGeneratorAPI;


public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost4200",
                builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
    });
        services.AddHttpContextAccessor();
        services.AddControllers();
        services.AddSingleton<IConfiguration>(Configuration);
        services.AddHttpClient("MyApi", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7184/");
        });
        services.AddDbContext<InvoiceTemplateContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AzureConnection"))
            
            );

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseCors("AllowLocalhost4200");
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
        app.UseRouting();
    }



}
