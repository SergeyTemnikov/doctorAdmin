using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace doctorAdmin;

public partial class MedDbContext : DbContext
{
    public MedDbContext()
    {
    }

    public MedDbContext(DbContextOptions<MedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiagnosesToMedCard> DiagnosesToMedCards { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DiseasesToMedCard> DiseasesToMedCards { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<MedCard> MedCards { get; set; }

    public virtual DbSet<MedInsurance> MedInsurances { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonImage> PersonImages { get; set; }

    public virtual DbSet<QrImage> QrImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.144.12;Database=medDB;user id=sa;password=P@ssw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiagnosesToMedCard>(entity =>
        {
            entity.ToTable("DiagnosesToMedCard");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDiagnoses).HasColumnName("idDiagnoses");
            entity.Property(e => e.IdMedCard).HasColumnName("idMedCard");

            entity.HasOne(d => d.IdDiagnosesNavigation).WithMany(p => p.DiagnosesToMedCards)
                .HasForeignKey(d => d.IdDiagnoses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiagnosesToMedCard_Diagnoses");

            entity.HasOne(d => d.IdMedCardNavigation).WithMany(p => p.DiagnosesToMedCards)
                .HasForeignKey(d => d.IdMedCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiagnosesToMedCard_MedCard");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<DiseasesToMedCard>(entity =>
        {
            entity.ToTable("DiseasesToMedCard");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDiseases).HasColumnName("idDiseases");
            entity.Property(e => e.IdMedCard).HasColumnName("idMedCard");

            entity.HasOne(d => d.IdDiseasesNavigation).WithMany(p => p.DiseasesToMedCards)
                .HasForeignKey(d => d.IdDiseases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseasesToMedCard_Diseases");

            entity.HasOne(d => d.IdMedCardNavigation).WithMany(p => p.DiseasesToMedCards)
                .HasForeignKey(d => d.IdMedCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseasesToMedCard_MedCard");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RecForTreatmenr).HasMaxLength(200);
            entity.Property(e => e.Results).HasMaxLength(200);
            entity.Property(e => e.TypeOfEvent).HasMaxLength(50);

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Person");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image1)
                .HasMaxLength(50)
                .HasColumnName("Image");
        });

        modelBuilder.Entity<MedCard>(entity =>
        {
            entity.ToTable("MedCard");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfReceiving).HasColumnType("date");
            entity.Property(e => e.IdDiagnoses).HasColumnName("idDiagnoses");
            entity.Property(e => e.IdDiseasesHistory).HasColumnName("idDiseasesHistory");
            entity.Property(e => e.Number).HasMaxLength(50);
            entity.Property(e => e.QrNumber).HasMaxLength(200);
        });

        modelBuilder.Entity<MedInsurance>(entity =>
        {
            entity.ToTable("MedInsurance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfEnd).HasColumnType("date");
            entity.Property(e => e.InsuranceCompany).HasMaxLength(50);
            entity.Property(e => e.Number).HasMaxLength(50);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.IdImage).HasColumnName("idImage");
            entity.Property(e => e.IdMedCard).HasColumnName("idMedCard");
            entity.Property(e => e.IdMedInsurance).HasColumnName("idMedInsurance");
            entity.Property(e => e.Job).HasMaxLength(50);
            entity.Property(e => e.PassportData).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.SecondName).HasMaxLength(50);

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("FK_Person_Gender");

            entity.HasOne(d => d.IdImageNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdImage)
                .HasConstraintName("FK_Person_Images");

            entity.HasOne(d => d.IdMedCardNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdMedCard)
                .HasConstraintName("FK_Person_MedCard");

            entity.HasOne(d => d.IdMedInsuranceNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdMedInsurance)
                .HasConstraintName("FK_Person_MedInsurance");
        });

        modelBuilder.Entity<PersonImage>(entity =>
        {
            entity.ToTable("PersonImage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdImage).HasColumnName("idImage");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");

            entity.HasOne(d => d.IdImageNavigation).WithMany(p => p.PersonImages)
                .HasForeignKey(d => d.IdImage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonImage_Images");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonImages)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonImage_Person");
        });

        modelBuilder.Entity<QrImage>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdImage).HasColumnName("idImage");
            entity.Property(e => e.IdQr).HasColumnName("idQr");

            entity.HasOne(d => d.IdImageNavigation).WithMany(p => p.QrImages)
                .HasForeignKey(d => d.IdImage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QrImages_Images");

            entity.HasOne(d => d.IdQrNavigation).WithMany(p => p.QrImages)
                .HasForeignKey(d => d.IdQr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QrImages_MedCard");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
