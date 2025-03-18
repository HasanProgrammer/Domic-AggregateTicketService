﻿// <auto-generated />
using System;
using Domic.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domic.Persistence.Migrations.Q
{
    [DbContext(typeof(SQLContext))]
    [Migration("20250318140358_AddSomeEntities")]
    partial class AddSomeEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domic.Core.Domain.Entities.ConsumerEventQuery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountOfRetry")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsumerEvents", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Category.Entities.CategoryQuery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "IsDeleted");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketCommentQuery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("TicketId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketQuery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Priority")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("Id", "IsDeleted");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.User.Entities.UserQuery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "IsDeleted");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketCommentQuery", b =>
                {
                    b.HasOne("Domic.Domain.Ticket.Entities.TicketQuery", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketQuery", b =>
                {
                    b.HasOne("Domic.Domain.Category.Entities.CategoryQuery", "Category")
                        .WithMany("Tickets")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Domic.Domain.User.Entities.UserQuery", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domic.Domain.Category.Entities.CategoryQuery", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketQuery", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domic.Domain.User.Entities.UserQuery", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
