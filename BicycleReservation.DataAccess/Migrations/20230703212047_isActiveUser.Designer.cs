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
    [Migration("20230703212047_isActiveUser")]
    partial class isActiveUser
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
                            PasswordHash = new byte[] { 47, 120, 80, 96, 224, 47, 80, 102, 250, 143, 224, 254, 136, 54, 86, 44, 9, 100, 155, 202, 194, 25, 143, 151, 238, 146, 244, 37, 149, 198, 225, 144, 109, 74, 196, 211, 113, 114, 146, 232, 20, 107, 222, 14, 233, 196, 205, 62, 133, 80, 119, 8, 65, 13, 161, 144, 104, 176, 121, 93, 208, 197, 167, 102 },
                            PasswordSalt = new byte[] { 7, 241, 106, 38, 166, 17, 31, 215, 105, 164, 231, 198, 195, 194, 80, 213, 241, 171, 42, 171, 120, 96, 19, 210, 253, 72, 182, 233, 96, 79, 145, 245, 192, 73, 224, 255, 29, 49, 115, 214, 111, 68, 74, 175, 71, 32, 78, 142, 80, 197, 26, 147, 61, 182, 145, 34, 10, 132, 106, 48, 139, 82, 118, 246, 36, 214, 124, 195, 142, 34, 102, 67, 6, 23, 52, 115, 143, 37, 4, 188, 42, 80, 86, 170, 162, 164, 21, 137, 149, 100, 181, 141, 128, 94, 29, 15, 107, 52, 31, 155, 226, 148, 36, 252, 75, 63, 202, 85, 75, 182, 249, 215, 48, 253, 211, 185, 102, 86, 65, 97, 110, 14, 157, 42, 198, 9, 175, 33 },
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
