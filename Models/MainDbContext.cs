using System;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia6_zen_s19743.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                ("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19743;Integrated Security=True"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});

            SeedDoctors(modelBuilder);
            SeedPatients(modelBuilder);
            SeedMedicaments(modelBuilder);
            SeedPrescriptions(modelBuilder);
            SeedPrescriptionMedicament(modelBuilder);
        }

        private void SeedPrescriptionMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasData(
                    new PrescriptionMedicament
                    {
                        IdPrescription = 1,
                        IdMedicament = 1,
                        Details = "Don't overdose",
                        Dose = 4,
                    }
                );
        }

        private void SeedPrescriptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>()
                .HasData(
                    new Prescription
                    {
                        IdPrescription = 1,
                        IdDoctor = 1,
                        IdPatient = 2,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(1)
                    }
                );
        }

        private void SeedMedicaments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasData(
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "Medicament 1",
                        Description = "This medicament treats some illness",
                        Type = "Type 1"
                    },
                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "Medicament 2",
                        Description = "This medicament treats other illness",
                        Type = "Type 2"
                    });
        }

        private void SeedPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Paweł",
                        LastName = "Nowak",
                        Birthday = Convert.ToDateTime("1990-07-26T00:00:00")
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Marek",
                        LastName = "Markowski",
                        Birthday = Convert.ToDateTime("1973-02-13T00:00:00")
                    });
        }

        private void SeedDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Email = "jan@kowalski.pl"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Grzegorz",
                        LastName = "Krychowiak",
                        Email = "grzegorz@krychowiak.pl"
                    });
        }
    }
}