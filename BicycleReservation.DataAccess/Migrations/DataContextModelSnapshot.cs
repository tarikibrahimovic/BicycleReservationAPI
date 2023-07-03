﻿// <auto-generated />
using System;
using BicycleReservation.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            PasswordHash = new byte[] { 56, 240, 91, 29, 6, 139, 120, 251, 29, 37, 205, 126, 1, 223, 49, 230, 109, 194, 210, 111, 58, 137, 54, 118, 114, 76, 249, 45, 53, 26, 242, 196, 194, 136, 48, 212, 239, 107, 86, 77, 189, 208, 127, 223, 112, 10, 254, 205, 13, 74, 110, 127, 175, 205, 248, 42, 33, 90, 201, 34, 22, 66, 30, 176 },
                            PasswordSalt = new byte[] { 209, 135, 44, 98, 216, 31, 149, 243, 146, 192, 37, 123, 90, 138, 20, 138, 176, 116, 172, 67, 175, 204, 197, 128, 139, 36, 24, 204, 27, 144, 176, 239, 108, 131, 177, 37, 236, 211, 191, 130, 121, 188, 218, 178, 28, 83, 74, 212, 209, 4, 228, 238, 79, 232, 131, 200, 32, 70, 154, 190, 111, 99, 16, 40, 210, 237, 200, 105, 20, 15, 92, 140, 247, 247, 40, 84, 217, 114, 237, 49, 29, 122, 224, 71, 231, 169, 71, 144, 229, 208, 90, 141, 159, 79, 146, 62, 63, 58, 160, 10, 129, 209, 127, 2, 194, 210, 249, 53, 133, 178, 249, 192, 233, 92, 54, 38, 234, 9, 153, 234, 193, 127, 220, 153, 124, 93, 127, 78 },
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
