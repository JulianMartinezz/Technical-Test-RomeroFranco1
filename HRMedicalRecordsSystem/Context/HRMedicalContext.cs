﻿using System;
using System.Collections.Generic;
using HRMedicalRecordsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMedicalRecordsSystem.Context;

public partial class HRMedicalContext : DbContext
{
    public HRMedicalContext()
    {
    }

    public HRMedicalContext(DbContextOptions<HRMedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MedicalRecordType> MedicalRecordTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TMedicalRecord> TMedicalRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RRHH_DB;Username=postgres;Password=Gaston1216");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalRecordType>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordTypeId).HasName("medical_record_type_pkey");

            entity.ToTable("medical_record_type");

            entity.Property(e => e.MedicalRecordTypeId).HasColumnName("medical_record_type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TMedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("t_medical_record_pkey");

            entity.ToTable("t_medical_record");

            entity.Property(e => e.MedicalRecordId).HasColumnName("medical_record_id");
            entity.Property(e => e.AreaChange)
                .HasMaxLength(2)
                .HasColumnName("area_change");
            entity.Property(e => e.Audiometry)
                .HasMaxLength(2)
                .HasColumnName("audiometry");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(2000)
                .HasColumnName("created_by");
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(2000)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletionDate).HasColumnName("deletion_date");
            entity.Property(e => e.DeletionReason)
                .HasMaxLength(2000)
                .HasColumnName("deletion_reason");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(100)
                .HasColumnName("diagnosis");
            entity.Property(e => e.Disability)
                .HasMaxLength(2)
                .HasColumnName("disability");
            entity.Property(e => e.DisabilityPercentage)
                .HasPrecision(10)
                .HasColumnName("disability_percentage");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.ExecuteExtra)
                .HasMaxLength(2)
                .HasColumnName("execute_extra");
            entity.Property(e => e.ExecuteMicros)
                .HasMaxLength(2)
                .HasColumnName("execute_micros");
            entity.Property(e => e.FatherData)
                .HasMaxLength(2000)
                .HasColumnName("father_data");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.MedicalBoard)
                .HasMaxLength(200)
                .HasColumnName("medical_board");
            entity.Property(e => e.MedicalRecordTypeId).HasColumnName("medical_record_type_id");
            entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(2000)
                .HasColumnName("modified_by");
            entity.Property(e => e.MotherData)
                .HasMaxLength(2000)
                .HasColumnName("mother_data");
            entity.Property(e => e.Observations)
                .HasMaxLength(2000)
                .HasColumnName("observations");
            entity.Property(e => e.OtherFamilyData)
                .HasMaxLength(2000)
                .HasColumnName("other_family_data");
            entity.Property(e => e.PositionChange)
                .HasMaxLength(2)
                .HasColumnName("position_change");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.VoiceEvaluation)
                .HasMaxLength(2)
                .HasColumnName("voice_evaluation");

            entity.HasOne(d => d.MedicalRecordType).WithMany(p => p.TMedicalRecords)
                .HasForeignKey(d => d.MedicalRecordTypeId)
                .HasConstraintName("fk_medical_record_type");

            entity.HasOne(d => d.Status).WithMany(p => p.TMedicalRecords)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_status_id_record");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
