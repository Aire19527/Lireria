﻿// <auto-generated />
using System;
using Infrastructure.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200223005333_initialBdLibrary")]
    partial class initialBdLibrary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Entity.Entity.BookEntity", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdEditorial");

                    b.Property<long>("SuggestedPrice");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("IdBook");

                    b.HasIndex("IdEditorial");

                    b.ToTable("Book","Library");
                });

            modelBuilder.Entity("Infrastructure.Entity.Entity.EditorialEntity", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("IdEditorial");

                    b.ToTable("Editorial","Library");
                });

            modelBuilder.Entity("Infrastructure.Entity.Entity.BookEntity", b =>
                {
                    b.HasOne("Infrastructure.Entity.Entity.EditorialEntity", "EditorialEntity")
                        .WithMany("BookEntity")
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
