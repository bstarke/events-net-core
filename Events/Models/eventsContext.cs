using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Events.Models
{
    public partial class eventsContext : DbContext
    {
        public eventsContext()
        {
        }

        public eventsContext(DbContextOptions<eventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Child { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Guardian> Guardian { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            Console.Out.WriteLine("Options Configured? : " + optionsBuilder.IsConfigured);
            if (!optionsBuilder.IsConfigured)
            {
//                optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQLCONNSTR_DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>(entity =>
            {
                entity.ToTable("child");

                entity.HasIndex(e => e.GuardianId)
                    .HasName("FKecmx78xnwoav9aq60wfrg8kl0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.GuardianId)
                    .HasColumnName("guardian_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Guardian)
                    .WithMany(p => p.Child)
                    .HasForeignKey(d => d.GuardianId)
                    .HasConstraintName("FKecmx78xnwoav9aq60wfrg8kl0");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.EventDate)
                    .HasName("UK_tr0nlc9oh7yy3fexwkcbmudio")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CreateDate).HasColumnName("create_date").ValueGeneratedOnAdd();

                entity.Property(e => e.EventDate)
                    .HasColumnName("event_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date").ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RegistrationOpen)
                    .HasColumnName("registration_open")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Guardian>(entity =>
            {
                entity.ToTable("guardian");

                entity.HasIndex(e => e.Email)
                    .HasName("email_unique_index")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasColumnType("int(11)");
            });
        }
    }
}
