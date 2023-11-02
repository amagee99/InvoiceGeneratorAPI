

namespace InvoiceGeneratorAPI.Models;

using Microsoft.EntityFrameworkCore;


public class InvoiceTemplateContext : DbContext
{
    public InvoiceTemplateContext(DbContextOptions<InvoiceTemplateContext> options)
        : base(options)
    {
    }

    public DbSet<InvoiceTemplate> InvoiceTemplates { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:invoice-generator-server.database.windows.net,1433;Initial Catalog=SerendellInvoicingDb;Persist Security Info=False;User ID=agmagee99;Password=JKNVZrz6G7a!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}