﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingAPI.Data;

namespace TrainingAPI.Migrations
{
    [DbContext(typeof(TrainingContext))]
    partial class TrainingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TrainingAPI.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Training");
                });
#pragma warning restore 612, 618
        }
    }
}
