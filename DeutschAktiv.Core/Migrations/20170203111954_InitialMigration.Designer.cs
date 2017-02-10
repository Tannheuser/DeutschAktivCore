﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DeutschAktiv.Core.Models;

namespace DeutschAktiv.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170203111954_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DeutschAktiv.Core.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("IconClass");

                    b.Property<string>("Route");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });
        }
    }
}
