﻿// <auto-generated />
using System;
using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MakersOfDenmark.Data.Migrations
{
    [DbContext(typeof(MakersOfDenmarkDbContext))]
    [Migration("20201125095339_initial_psql3")]
    partial class initial_psql3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("text");

                    b.Property<string>("Zipcode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Auth.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Badges.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(280)")
                        .HasMaxLength(280);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IssuerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IssuerId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("character varying(280)")
                        .HasMaxLength(280);

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MakerspaceId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MakerspaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.EventBadge", b =>
                {
                    b.Property<int>("BadgeId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.HasKey("BadgeId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventBadges");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.EventRegistration", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("HasAttended")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Access_Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("CVR")
                        .HasColumnType("character varying(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Logo_Url")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Space_Type")
                        .HasColumnType("text");

                    b.Property<string>("X_Coords")
                        .HasColumnType("text");

                    b.Property<string>("Y_Coords")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Makerspaces");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.MakerspaceBadge", b =>
                {
                    b.Property<int>("BadgeId")
                        .HasColumnType("integer");

                    b.Property<int>("MakerspaceId")
                        .HasColumnType("integer");

                    b.HasKey("BadgeId", "MakerspaceId");

                    b.HasIndex("MakerspaceId");

                    b.ToTable("MakerspaceBadges");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.MakerspaceUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("MakerspaceId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "MakerspaceId");

                    b.HasIndex("MakerspaceId");

                    b.ToTable("MakerspaceUsers");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.UserRelations.UserBadge", b =>
                {
                    b.Property<int>("BadgeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("BadgeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Auth.User", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Badges.Badge", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", "Issuer")
                        .WithMany("Badges")
                        .HasForeignKey("IssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.Event", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", "MakerspaceHost")
                        .WithMany("Events")
                        .HasForeignKey("MakerspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.EventBadge", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Badges.Badge", "Badge")
                        .WithMany("EventBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Events.Event", "Event")
                        .WithMany("EventBadges")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Events.EventRegistration", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Events.Event", "Event")
                        .WithMany("RegisteredUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", "User")
                        .WithMany("EventsRegisteredFor")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Address", "Address")
                        .WithMany("Makerspaces")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.MakerspaceBadge", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Badges.Badge", "Badge")
                        .WithMany("MakerspaceBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", "Makerspaces")
                        .WithMany("MakerspaceBadges")
                        .HasForeignKey("MakerspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.Makerspaces.MakerspaceUser", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Makerspaces.Makerspace", "Makerspaces")
                        .WithMany("MakerspaceUsers")
                        .HasForeignKey("MakerspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", "User")
                        .WithMany("MakerspacesJoined")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakersOfDenmark.Core.Models.UserRelations.UserBadge", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Badges.Badge", "Badge")
                        .WithMany("UserBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("MakersOfDenmark.Core.Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
