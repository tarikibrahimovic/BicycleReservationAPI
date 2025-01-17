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
    [Migration("20230703214755_DeletedStationDeletedColumn")]
    partial class DeletedStationDeletedColumn
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
                            PasswordHash = new byte[] { 233, 252, 199, 246, 218, 29, 228, 57, 234, 34, 202, 102, 2, 75, 199, 186, 249, 18, 131, 60, 95, 11, 27, 72, 79, 211, 224, 242, 140, 134, 49, 208, 33, 114, 245, 185, 76, 97, 93, 21, 91, 91, 164, 98, 166, 198, 212, 133, 173, 59, 73, 217, 83, 58, 175, 127, 73, 217, 91, 195, 175, 116, 126, 15 },
                            PasswordSalt = new byte[] { 208, 217, 156, 91, 83, 172, 3, 34, 3, 87, 217, 33, 38, 120, 66, 192, 195, 216, 155, 146, 68, 153, 117, 176, 158, 81, 178, 198, 170, 188, 253, 174, 47, 186, 124, 253, 199, 165, 223, 226, 182, 99, 47, 76, 21, 93, 49, 74, 79, 166, 132, 230, 186, 242, 97, 68, 45, 16, 56, 191, 52, 140, 254, 90, 63, 222, 12, 123, 56, 247, 245, 178, 67, 246, 175, 166, 112, 0, 82, 149, 60, 237, 49, 125, 150, 40, 28, 209, 182, 202, 53, 167, 206, 0, 227, 42, 86, 100, 188, 255, 94, 13, 216, 86, 85, 226, 19, 28, 69, 98, 139, 150, 19, 27, 78, 244, 146, 16, 95, 75, 43, 49, 23, 167, 167, 176, 7, 47 },
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
