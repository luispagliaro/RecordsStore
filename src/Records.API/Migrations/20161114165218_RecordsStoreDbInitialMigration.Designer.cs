using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Records.API.Entities;

namespace Records.API.Migrations
{
    [DbContext(typeof(RecordsStoreContext))]
    [Migration("20161114165218_RecordsStoreDbInitialMigration")]
    partial class RecordsStoreDbInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Records.API.Entities.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("Records.API.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BandId");

                    b.Property<int>("Price");

                    b.Property<int>("ReleaseYear");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Records.API.Entities.Record", b =>
                {
                    b.HasOne("Records.API.Entities.Band", "Band")
                        .WithMany("Records")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
