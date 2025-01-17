﻿// <auto-generated />
using System;
using BicycleReservation.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230705103819_ServiceAdded")]
    partial class ServiceAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Bicycle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Breakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BicycleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResolvedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BicycleId");

                    b.ToTable("Breakdowns");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BicycleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("CostPerHour")
                        .HasColumnType("float");

                    b.Property<int?>("EndStationId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StartStationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BicycleId");

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BicycleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BicycleId");

                    b.HasIndex("UserId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForgotPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            IsActive = true,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 202, 39, 53, 62, 214, 90, 142, 97, 227, 254, 62, 67, 11, 86, 64, 42, 178, 207, 198, 91, 227, 161, 35, 125, 24, 86, 91, 30, 66, 55, 146, 139, 202, 103, 105, 144, 22, 45, 232, 74, 190, 139, 237, 38, 185, 18, 163, 211, 104, 238, 238, 151, 35, 21, 7, 25, 73, 30, 59, 156, 160, 248, 188, 78 },
                            PasswordSalt = new byte[] { 138, 159, 24, 32, 202, 229, 37, 75, 198, 195, 56, 131, 211, 150, 57, 77, 205, 92, 93, 67, 124, 183, 181, 159, 22, 28, 173, 191, 82, 61, 18, 57, 251, 186, 204, 65, 30, 178, 171, 243, 156, 224, 182, 76, 86, 35, 130, 133, 186, 165, 134, 178, 116, 147, 17, 161, 186, 91, 100, 249, 175, 48, 207, 163, 168, 135, 194, 26, 8, 75, 160, 97, 189, 198, 89, 80, 112, 189, 173, 173, 245, 167, 1, 11, 178, 11, 8, 216, 12, 205, 16, 43, 161, 110, 56, 157, 135, 164, 148, 2, 92, 190, 51, 133, 72, 175, 221, 67, 28, 136, 163, 222, 84, 26, 77, 67, 222, 90, 156, 204, 227, 154, 149, 96, 159, 66, 116, 200 },
                            Role = 3,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.UserCredits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Credits")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Breakdown", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.Bicycle", "Bicycle")
                        .WithMany("Breakdowns")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Record", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.Bicycle", "Bicycle")
                        .WithMany("Records")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BicycleReservation.Domain.Entities.Station", "EndStation")
                        .WithMany()
                        .HasForeignKey("EndStationId");

                    b.HasOne("BicycleReservation.Domain.Entities.Station", "StartStation")
                        .WithMany()
                        .HasForeignKey("StartStationId");

                    b.HasOne("BicycleReservation.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");

                    b.Navigation("EndStation");

                    b.Navigation("StartStation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Service", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.Bicycle", "Bicycle")
                        .WithMany("Services")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BicycleReservation.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.UserCredits", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.User", "User")
                        .WithOne("Credits")
                        .HasForeignKey("BicycleReservation.Domain.Entities.UserCredits", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Bicycle", b =>
                {
                    b.Navigation("Breakdowns");

                    b.Navigation("Records");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.User", b =>
                {
                    b.Navigation("Credits");
                });
#pragma warning restore 612, 618
        }
    }
}
