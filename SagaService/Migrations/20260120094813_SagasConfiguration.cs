using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaService.Migrations
{
    /// <inheritdoc />
    public partial class SagasConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestCompletionState",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    XpAwarded = table.Column<bool>(type: "bit", nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCompletionState", x => x.CorrelationId);
                });

            migrationBuilder.CreateTable(
                name: "QuestCreationState",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCreationState", x => x.CorrelationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestCompletionState");

            migrationBuilder.DropTable(
                name: "QuestCreationState");
        }
    }
}
