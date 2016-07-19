using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace inmemowordlist.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Academic = table.Column<int>(nullable: false),
                    Fiction = table.Column<int>(nullable: false),
                    Magazine = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Newspaper = table.Column<int>(nullable: false),
                    PartOfSpeech = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Spoken = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
