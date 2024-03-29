﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CrudApi.DataModels;

namespace CrudApi.DbContextFolder
{
    public partial class ApiCrudNet6Context : DbContext
    {
        public ApiCrudNet6Context()
        {
        }

        public ApiCrudNet6Context(DbContextOptions<ApiCrudNet6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Worker)
                    .HasForeignKey<Worker>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}