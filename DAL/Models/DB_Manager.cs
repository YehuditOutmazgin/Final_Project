using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class DB_Manager : DbContext
{
    public DB_Manager()
    {
    }

    public DB_Manager(DbContextOptions<DB_Manager> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Hmo> Hmos { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Therapist> Therapists { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\FinalProj\\Final_Project\\DAL\\Data\\DB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__tmp_ms_x__8ECDFCA29761D564");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TherapistId).HasColumnName("TherapistID");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Patie__51300E55");

            entity.HasOne(d => d.Therapist).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.TherapistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Thera__5AB9788F");
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__BankAcco__349DA586B65DAF91");

            entity.ToTable("BankAccount");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BillingAccount).HasMaxLength(50);
            entity.Property(e => e.BranchNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TherapistId).HasColumnName("TherapistID");
        });

        modelBuilder.Entity<Hmo>(entity =>
        {
            entity.HasKey(e => e.HmoId).HasName("PK__HMO__E95C1D2F5985CAC5");

            entity.ToTable("HMO");

            entity.Property(e => e.HmoId).HasColumnName("HMO_ID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__ Invoice__D796AAD5E569A1F3");

            entity.ToTable(" Invoices");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Patient).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ Invoices__Patie__3E1D39E1");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC34695D48E27");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HmoId).HasColumnName("HMO_ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Hmo).WithMany(p => p.Patients)
                .HasForeignKey(d => d.HmoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Patients__HMO_ID__71D1E811");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__ Prescri__40130812C63C72C1");

            entity.ToTable(" Prescriptions");

            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Instructions).HasColumnType("text");
            entity.Property(e => e.Medication)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.TherapistId).HasColumnName("TherapistID");

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ Prescrip__Patie__42E1EEFE");

            entity.HasOne(d => d.Therapist).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.TherapistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ Prescrip__Thera__607251E5");
        });

        modelBuilder.Entity<Therapist>(entity =>
        {
            entity.HasKey(e => e.TherapistId).HasName("PK__Therapis__4D6219123B144696");

            entity.Property(e => e.TherapistId)
                .ValueGeneratedNever()
                .HasColumnName("TherapistID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.BankAccount).WithMany(p => p.Therapists)
                .HasForeignKey(d => d.BankAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Therapist__BankA__5BAD9CC8");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId).HasName("PK__ Treatme__1A57B71135F78FB5");

            entity.ToTable(" Treatments");

            entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TreatmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
