using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cars.Models
{
    public partial class CarsContext : DbContext
    {
        

        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Exchange> Exchange { get; set; }
        public virtual DbSet<Guarantee> Guarantee { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-485I5P3;Database=Cars;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Identity).IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasColumnType("numeric(1, 0)");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.Property(e => e.ModelId).HasColumnName("Model_Id");

                entity.Property(e => e.State).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Model");
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Type).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Exchange)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exchange_Agent");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Exchange)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exchange_Cars");

                entity.HasOne(d => d.Guarantee)
                    .WithMany(p => p.Exchange)
                    .HasForeignKey(d => d.GuaranteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exchange_Guarantee");
            });

            modelBuilder.Entity<Guarantee>(entity =>
            {
                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.Notes).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rental_Agent");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rental_Cars");
            });
        }
    }
}
