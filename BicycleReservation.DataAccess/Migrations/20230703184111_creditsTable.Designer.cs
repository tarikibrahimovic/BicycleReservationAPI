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
    [Migration("20230703184111_creditsTable")]
    partial class creditsTable
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

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bicycles");
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

                    b.Property<float?>("CostPerHour")
                        .HasColumnType("real");

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
                            LastName = "Admin",
                            PasswordHash = new byte[] { 103, 83, 95, 91, 126, 47, 81, 15, 224, 241, 47, 111, 160, 97, 124, 126, 173, 162, 239, 103, 182, 73, 159, 156, 126, 147, 55, 134, 37, 42, 94, 217, 24, 216, 243, 117, 31, 208, 80, 182, 127, 51, 255, 251, 66, 28, 247, 128, 50, 52, 163, 6, 51, 121, 163, 252, 74, 213, 237, 69, 6, 186, 158, 183 },
                            PasswordSalt = new byte[] { 131, 159, 5, 132, 167, 218, 85, 189, 50, 227, 181, 252, 72, 90, 91, 215, 4, 171, 4, 143, 111, 141, 211, 192, 242, 118, 5, 76, 6, 241, 79, 0, 223, 117, 36, 53, 186, 33, 38, 206, 224, 15, 138, 14, 240, 179, 118, 36, 112, 106, 241, 20, 220, 1, 64, 253, 45, 175, 38, 7, 184, 205, 141, 203, 129, 103, 125, 229, 22, 128, 184, 144, 172, 252, 53, 246, 15, 172, 59, 59, 209, 91, 12, 49, 232, 137, 232, 8, 240, 186, 72, 33, 57, 45, 23, 220, 11, 0, 66, 58, 240, 6, 210, 36, 76, 68, 70, 169, 20, 157, 49, 236, 100, 129, 18, 89, 175, 14, 87, 51, 229, 163, 59, 199, 115, 19, 37, 2 },
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

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.Record", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.Bicycle", "Bicycle")
                        .WithMany()
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

            modelBuilder.Entity("BicycleReservation.Domain.Entities.UserCredits", b =>
                {
                    b.HasOne("BicycleReservation.Domain.Entities.User", "User")
                        .WithOne("Credits")
                        .HasForeignKey("BicycleReservation.Domain.Entities.UserCredits", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BicycleReservation.Domain.Entities.User", b =>
                {
                    b.Navigation("Credits");
                });
#pragma warning restore 612, 618
        }
    }
}
