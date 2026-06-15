using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndCombater.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HitDice = table.Column<string>(type: "TEXT", nullable: false),
                    SavingThrowProficiencies = table.Column<string>(type: "TEXT", nullable: false),
                    WeaponProficiencies = table.Column<string>(type: "TEXT", nullable: false),
                    ArmorProficiencies = table.Column<string>(type: "TEXT", nullable: false),
                    ToolProficiencies = table.Column<string>(type: "TEXT", nullable: false),
                    SkillProficiencies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterClass = table.Column<string>(type: "TEXT", nullable: false),
                    Subclass = table.Column<string>(type: "TEXT", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    AC = table.Column<int>(type: "INTEGER", nullable: false),
                    Initiative = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterImage = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
