using Microsoft.EntityFrameworkCore;
using TicketsAPI.Models;

namespace TicketsAPI.Data;

public class TicketContext : DbContext
{
    public TicketContext(DbContextOptions<TicketContext> options) : base(options)
    {
    }

    public DbSet<Segment> Segments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Segment>()
            .HasIndex(p => new { p.ticket_number, p.serial_number })
            .IsUnique();
    }
}