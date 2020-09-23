﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonDirectory.Infrastructure.DBContexts;

namespace PersonDirectory.Infrastructure.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20200923131437_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonDirectory.Core.Entities.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonDirectory.Core.Entities.RelatedPersonToPerson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedPersonID")
                        .HasColumnType("int");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RelatedPersonID");

                    b.ToTable("RelatedPersonToPerson");
                });

            modelBuilder.Entity("PersonDirectory.Core.Entities.TelNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("TelNumberType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("TelNumber");
                });

            modelBuilder.Entity("PersonDirectory.Core.Entities.RelatedPersonToPerson", b =>
                {
                    b.HasOne("PersonDirectory.Core.Entities.Person", "Person")
                        .WithMany("ReladedPersons")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersonDirectory.Core.Entities.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonID");
                });

            modelBuilder.Entity("PersonDirectory.Core.Entities.TelNumber", b =>
                {
                    b.HasOne("PersonDirectory.Core.Entities.Person", null)
                        .WithMany("TelNumbers")
                        .HasForeignKey("PersonID");
                });
#pragma warning restore 612, 618
        }
    }
}
