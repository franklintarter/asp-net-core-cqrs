﻿// <auto-generated />
using System;
using AspNetCore.CQRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCore.CQRS.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181129013536_Add_Email_To_Person")]
    partial class Add_Email_To_Person
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCore.CQRS.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastModifiedAt");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AspNetCore.CQRS.Domain.Person", b =>
                {
                    b.OwnsOne("AspNetCore.CQRS.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid?>("PersonId");

                            b1.Property<string>("Value")
                                .HasColumnName("Email");

                            b1.ToTable("Person");

                            b1.HasOne("AspNetCore.CQRS.Domain.Person")
                                .WithOne("Email")
                                .HasForeignKey("AspNetCore.CQRS.Domain.ValueObjects.Email", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("AspNetCore.CQRS.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("PersonId");

                            b1.Property<string>("Value")
                                .HasColumnName("Name");

                            b1.ToTable("Person");

                            b1.HasOne("AspNetCore.CQRS.Domain.Person")
                                .WithOne("Name")
                                .HasForeignKey("AspNetCore.CQRS.Domain.ValueObjects.Name", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
