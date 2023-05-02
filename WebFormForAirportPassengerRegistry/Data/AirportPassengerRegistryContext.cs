using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebFormForAirportPassengerRegistry;

public partial class AirportPassengerRegistryContext : DbContext
{
    public AirportPassengerRegistryContext()
    {
    }

    public AirportPassengerRegistryContext(DbContextOptions<AirportPassengerRegistryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightTicket> FlightTickets { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Search> Searches { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    public virtual DbSet<Visa> Visas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=AIRPORT_PASSENGER_REGISTRY; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__3214EC07FA2F02A4");

            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.PlaceOfArrival).HasMaxLength(50);
            entity.Property(e => e.PlaceOfDeparture).HasMaxLength(50);

            entity.HasOne(d => d.Terminal).WithMany(p => p.Flights)
                .HasForeignKey(d => d.TerminalId)
                .HasConstraintName("FK__Flights__Termina__440B1D61");
        });

        modelBuilder.Entity<FlightTicket>(entity =>
        {
            entity.HasKey(e => e.FlightTicketId).HasName("PK__FlightTi__3214EC073707D734");

            entity.Property(e => e.Class)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LuggageVolume).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LuggageWeight).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightTickets)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__FlightTic__Fligh__4D94879B");

            entity.HasOne(d => d.Passenger).WithMany(p => p.FlightTickets)
                .HasForeignKey(d => d.PassengerId)
                .HasConstraintName("FK__FlightTic__Passe__4F7CD00D");

            entity.HasOne(d => d.Visa).WithMany(p => p.FlightTickets)
                .HasForeignKey(d => d.VisaId)
                .HasConstraintName("FK__FlightTick__Visa__4E88ABD4");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Passenge__3214EC07C3489574");

            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Birthplace).HasMaxLength(100);
            entity.Property(e => e.Citizenship).HasMaxLength(50);
            entity.Property(e => e.Communication).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Residency).HasMaxLength(150);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Search>(entity =>
        {
            entity.HasKey(e => e.SearchId).HasName("PK__Searches__3214EC07B643ECEC");

            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.DateSince).HasColumnType("date");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Passenger).WithMany(p => p.Searches)
                .HasForeignKey(d => d.PassengerId)
                .HasConstraintName("FK__Searches__Passen__534D60F1");
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => e.TerminalId).HasName("PK__Terminal__3214EC07DAC12DA3");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.VisaId).HasName("PK__Visas__3214EC072705346A");

            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.ValidTill).HasColumnType("date");
            entity.Property(e => e.VisaType).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
