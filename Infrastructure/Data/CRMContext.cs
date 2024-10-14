using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost;Database=CRMContext;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionBuilder);
        }
        //entities
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<InteractionTypes> InteractionTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<CampaignTypes> CampaignTypes { get; set; }
        //modelado de tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(i => i.Id).ValueGeneratedNever().IsRequired();
                entity.Property(n => n.Name).HasColumnType("nvarchar(25)").IsRequired();
            });

            modelBuilder.Entity<Interactions>(entity => 
            {
                entity.HasKey(x => x.InteractionID);
                entity.Property(i =>i.InteractionID).ValueGeneratedOnAdd().IsRequired();
                entity.HasOne<Projects>(i => i.Projects)
                    .WithMany(i => i.Interactions)
                    .HasForeignKey(x => x.ProjectID);
                entity.HasOne<InteractionTypes>(i => i.InteractionTypes)
                    .WithMany(i => i.Interactions)
                    .HasForeignKey(x => x.InteractionType);
                entity.Property(n => n.Notes).HasColumnType("varchar(max)").IsRequired();
                entity.Property(d => d.Date).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.UserID);
                entity.Property(i => i.UserID).ValueGeneratedNever().IsRequired();
                entity.Property(n => n.Name).HasColumnType("nvarchar(255)").IsRequired();
                entity.Property(e => e.Email).HasColumnType("nvarchar(255)").IsRequired();
            });

            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(i => i.Id).ValueGeneratedNever().IsRequired();
                entity.Property(n => n.Name).HasColumnType("varchar(25)").IsRequired();
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(x => x.TaskID);
                entity.Property(i => i.TaskID).ValueGeneratedOnAdd().IsRequired();
                entity.Property(n => n.Name).HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(d => d.CreateDate).IsRequired();
                entity.HasOne<Projects>(i => i.Projects)
                    .WithMany(i => i.Tasks)
                    .HasForeignKey(x => x.ProjectID);
                entity.HasOne<Users>(i => i.Users)
                    .WithMany(t => t.Tasks)
                    .HasForeignKey(x => x.AssignedTo);
                entity.HasOne<Domain.Entities.TaskStatus>(t => t.TaskStatus)
                    .WithMany(t => t.Tasks)
                    .HasForeignKey(x => x.Status);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(x => x.ProjectID);
                entity.Property(i => i.ProjectID).ValueGeneratedOnAdd();
                entity.Property(n => n.ProjectName).HasColumnType("varchar(255)").IsRequired();
                entity.Property(d => d.CreateDate).IsRequired();
                entity.Property(d => d.StartDate).IsRequired();
                entity.Property(d => d.EndDate).IsRequired();
                entity.HasOne<CampaignTypes>(c => c.CampaignTypes)
                    .WithMany(i => i.Projects)
                    .HasForeignKey(x => x.CampaignType);
                entity.HasOne<Clients>(i => i.Clients)
                    .WithMany(t => t.Projects)
                    .HasForeignKey(x => x.ClientID);
            });

            modelBuilder.Entity<CampaignTypes>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(i => i.Id).ValueGeneratedNever().IsRequired();
                entity.Property(n => n.Name).HasColumnType("varchar(25)").IsRequired();
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(x => x.ClientID);
                entity.Property(i => i.ClientID).ValueGeneratedOnAdd().IsRequired();
                entity.Property(n => n.Name).HasColumnType("varchar(255)").IsRequired();
                entity.Property(e => e.Email).HasColumnType("varchar(255)").IsRequired();
                entity.Property(e => e.Phone).HasColumnType("varchar(255)").IsRequired();
                entity.Property(e => e.Company).HasColumnType("varchar(100)").IsRequired();
                entity.Property(e => e.Address).HasColumnType("varchar(max)").IsRequired();
            });
        }
    }
}
