using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inmemo.Wordlist.Models;

namespace inmemowordlist.Migrations
{
    [DbContext(typeof(WordlistDbContext))]
    [Migration("20160709202415_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inmemo.Wordlist.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Academic");

                    b.Property<int>("Fiction");

                    b.Property<int>("Magazine");

                    b.Property<string>("Name");

                    b.Property<int>("Newspaper");

                    b.Property<int>("PartOfSpeech");

                    b.Property<int>("Rank");

                    b.Property<int>("Spoken");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });
        }
    }
}
