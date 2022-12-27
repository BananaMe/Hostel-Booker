using backend.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class HostelBookingContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder
        {
            DataSource = "HostelBookingDB.db"
        };
        var connectionString = connectionStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(connection);
    }

    public HostelBookingContext(DbContextOptions<HostelBookingContext> options) : base(options) { }

    public DbSet<Hostel> Hostels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Availabilities { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>().ToTable("Hostel");
        modelBuilder.Entity<Room>().ToTable("Room");
        modelBuilder.Entity<Guest>().ToTable("Guest");
        modelBuilder.Entity<Reservation>().ToTable("Availability");
        modelBuilder.Entity<Reservation>().ToTable("Reservation");
    }
}
