using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestService.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQuestService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "Quests",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Quests");
        }
    }
}