using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace testapi2
{
    public partial class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=15Nov1998");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Employee>(entity =>
            {
                //entity.HasNoKey();

                entity.HasKey(e => e.Id);

                entity.ToTable("employee_system");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("int4").HasColumnName("id");

                entity.Property(e => e.Emp_name)
                    .HasColumnType("character varying")
                    .HasColumnName("emp_name");
                entity.Property(e => e.Dep_name)
    .HasColumnType("character varying")
    .HasColumnName("dep_name");


                entity.Property(e => e.Phone_number)
    .HasColumnType("character varying")
    .HasColumnName("phone_number");

                entity.Property(e => e.Email)
    .HasColumnType("character varying")
    .HasColumnName("email");

                entity.Property(e => e.Address)
    .HasColumnType("character varying")
    .HasColumnName("address");

                entity.Property(e => e.Birthdate)
    .HasColumnType("date")
    .HasColumnName("birthdate");

                entity.Property(e => e.Remarks)
    .HasColumnType("character varying")
    .HasColumnName("remarks");

                entity.Property(e => e.Photo)
    .HasColumnType("character varying")
    .HasColumnName("photo");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
