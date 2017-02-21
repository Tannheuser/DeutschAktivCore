using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Core.Constant;

namespace DeutschAktiv.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170217143355_ClubPrice")]
    partial class ClubPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DeutschAktiv.Core.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("IconClass");

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Price");

                    b.Property<string>("Subtitle");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("DeutschAktiv.Core.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Day");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Level");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Price");

                    b.Property<string>("Subtitle");

                    b.Property<string>("Time");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DeutschAktiv.Core.Models.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Day");

                    b.Property<bool>("Enabled");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Place");

                    b.Property<int>("Price");

                    b.Property<string>("Subtitle");

                    b.Property<string>("Teacher");

                    b.Property<string>("Time");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });
        }
    }
}
