﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MTrackerWebAPI.Migrations
{
    [DbContext(typeof(MTrackerDbContext))]
    partial class MTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MTrackerWebAPI.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.ManagerComments", b =>
                {
                    b.Property<int>("ManagerCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerCommentID"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectTaskID")
                        .HasColumnType("int");

                    b.HasKey("ManagerCommentID");

                    b.ToTable("ManagerComments");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.ProjectTasks", b =>
                {
                    b.Property<int>("ProjectTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTaskID"));

                    b.Property<int?>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<int?>("TaskCompletion")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TaskEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TaskStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserStoryID")
                        .HasColumnType("int");

                    b.HasKey("ProjectTaskID");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.Projects", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"));

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.Resource", b =>
                {
                    b.Property<int>("ResourceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceID"));

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillSets")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceID");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("MTrackerWebAPI.Model.UserStories", b =>
                {
                    b.Property<int>("UserStoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserStoryID"));

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserStoryID");

                    b.ToTable("UserStories");
                });
#pragma warning restore 612, 618
        }
    }
}
