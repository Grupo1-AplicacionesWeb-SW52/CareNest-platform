using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;

namespace WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        // DbSets - Inicialización para evitar errores de propiedades no inicializadas
        public DbSet<Caregiver> Caregivers { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        
        public DbSet<Workaround> Workarounds { get; set; } = null!;

        public DbSet<Tutor> Tutors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Tutor Configuration
            builder.Entity<Caregiver>(entity =>
            {
                entity.ToTable("caregivers");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Document).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProfileImg).HasMaxLength(250);

                entity.Property(e => e.Address).IsRequired().HasMaxLength(250);
                entity.Property(e => e.District).IsRequired().HasMaxLength(50);
            });

            // Configuración para Service
            builder.Entity<Service>(entity =>
            {
                entity.ToTable("services");
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Description).IsRequired();
                entity.Property(s => s.FarePerHour).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(s => s.Rating).HasColumnType("float").IsRequired();

                entity.HasOne(s => s.Caregiver)
                    .WithMany(c => c.Services)
                    .HasForeignKey(s => s.CaregiverId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Workarounds) // Relación uno a muchos
                    .WithOne(w => w.Service)
                    .HasForeignKey(w => w.ServiceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            // Configuración para Workaround
            builder.Entity<Workaround>(entity =>
            {
                entity.ToTable("workarounds");
                entity.HasKey(w => w.Id);

                entity.Property(w => w.Location).IsRequired().HasMaxLength(100);
                entity.HasOne(w => w.Service)
                    .WithMany(s => s.Workarounds)
                    .HasForeignKey(w => w.ServiceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración para Schedule
            builder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedules");
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Day).IsRequired().HasMaxLength(10);

                entity.OwnsOne(s => s.WorkHours, wh =>
                {
                    wh.Property(w => w.StartTime).HasColumnName("start_time").IsRequired().HasMaxLength(5);
                    wh.Property(w => w.EndTime).HasColumnName("end_time").IsRequired().HasMaxLength(5);
                });
            });
            
            // Tutor Configuration
            builder.Entity<Tutor>(entity =>
            {
                entity.ToTable("tutors");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Document).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProfileImg).HasMaxLength(250);

                entity.Property(e => e.Address).IsRequired().HasMaxLength(250);
                entity.Property(e => e.District).IsRequired().HasMaxLength(50);
            });
            
            // Configuración para UserPaymentMethod
            builder.Entity<UserPaymentMethod>(entity =>
            {
                entity.ToTable("user_payment_methods");
                entity.HasKey(upm => upm.Id);

                entity.Property(upm => upm.CardNumber).IsRequired().HasMaxLength(16);
                entity.Property(upm => upm.Cvv).IsRequired().HasMaxLength(3);
                entity.Property(upm => upm.CardHolder).IsRequired().HasMaxLength(100);
                entity.Property(upm => upm.ExpirationDate).IsRequired();

                entity.HasOne<Caregiver>().WithMany().HasForeignKey(upm => upm.CaregiverId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Tutor>().WithMany().HasForeignKey(upm => upm.TutorId).OnDelete(DeleteBehavior.Restrict);
            });
            
        }
    }
}
