using Microsoft.EntityFrameworkCore;

namespace InvoiceGeneratorAPI.Models;


public class InvoiceContext : DbContext
{
    public InvoiceContext(DbContextOptions<InvoiceContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoice { get; set; } = null!;
}