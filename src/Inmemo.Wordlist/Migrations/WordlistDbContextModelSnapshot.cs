using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Inmemo.Wordlist.Models;

namespace inmemowordlist.Migrations
{
    [DbContext(typeof(WordlistDbContext))]
    partial class WordlistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
