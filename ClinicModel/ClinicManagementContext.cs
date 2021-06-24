using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

#nullable disable
//Scaffold-DbContext "Data Source=(Localdb)\MSSQLLocalDB;Database=ClinicManagement;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ClinicModel
namespace ClinicManagement.ClinicModel
{
    public partial class ClinicManagementContext : DbContext
    {        
        public ClinicManagementContext()
        {
        }
        public ClinicManagementContext(DbContextOptions<ClinicManagementContext> options) : base(options) { }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(Localdb)\\MSSQLLocalDB;Database=ClinicManagement;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.BookingNumber)
                    .HasName("PK__Appointm__CB36BB4CD34785E4");

                entity.Property(e => e.BookingNumber).HasColumnName("bookingNumber");

                entity.Property(e => e.AppDoctor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appDoctor");

                entity.Property(e => e.BkdPatient)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bkdPatient");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("bookingDate");

                entity.Property(e => e.BookingSlot).HasColumnName("bookingSlot");

                entity.HasOne(d => d.AppDoctorNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppDoctor)
                    .HasConstraintName("FK__Appointme__appDo__3B75D760");

                entity.HasOne(d => d.BkdPatientNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.BkdPatient)
                    .HasConstraintName("FK__Appointme__bkdPa__3C69FB99");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorName)
                    .HasName("PK__Doctors__514FD5787ACB4F3D");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("doctorName");

                entity.Property(e => e.DoctorAge).HasColumnName("doctorAge");

                entity.Property(e => e.DoctorContactNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("doctorContactNumber");

                entity.Property(e => e.DoctorSpecialization)
                    .IsUnicode(false)
                    .HasColumnName("doctorSpecialization");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientName)
                    .HasName("PK__Patients__ACEB9A7A4C755FF4");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.Property(e => e.PatientAddress)
                    .IsUnicode(false)
                    .HasColumnName("patientAddress");

                entity.Property(e => e.PatientAge).HasColumnName("patientAge");

                entity.Property(e => e.PatientContactNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("patientContactNumber");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.LoginEmail)
                    .HasName("PK__Users__5D29F73ABC7C6196");

                entity.Property(e => e.LoginEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginEmail");

                entity.Property(e => e.FirstName)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LoginPassword)
                    .IsUnicode(false)
                    .HasColumnName("loginPassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
