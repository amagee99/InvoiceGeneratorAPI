namespace InvoiceGeneratorAPI;

using InvoiceGeneratorAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<InvoiceTemplate> InvoiceTemplates { get; set; }
}
