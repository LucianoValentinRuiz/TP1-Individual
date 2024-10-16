﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CRMContext))]
    partial class CRMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CampaignTypes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("CampaignTypes");
                });

            modelBuilder.Entity("Domain.Entities.Clients", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Domain.Entities.InteractionTypes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("InteractionTypes");
                });

            modelBuilder.Entity("Domain.Entities.Interactions", b =>
                {
                    b.Property<Guid>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InteractionType")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InteractionID");

                    b.HasIndex("InteractionType");

                    b.HasIndex("ProjectID");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Property<Guid>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CampaignType")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.HasIndex("CampaignType");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Entities.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.Property<Guid>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskID");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("ProjectID");

                    b.HasIndex("Status");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Interactions", b =>
                {
                    b.HasOne("Domain.Entities.InteractionTypes", "InteractionTypes")
                        .WithMany("Interactions")
                        .HasForeignKey("InteractionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Projects", "Projects")
                        .WithMany("Interactions")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InteractionTypes");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.HasOne("Domain.Entities.CampaignTypes", "CampaignTypes")
                        .WithMany("Projects")
                        .HasForeignKey("CampaignType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Clients", "Clients")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignTypes");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.HasOne("Domain.Entities.Users", "Users")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Projects", "Projects")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TaskStatus", "TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("TaskStatus");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.CampaignTypes", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Clients", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.InteractionTypes", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
