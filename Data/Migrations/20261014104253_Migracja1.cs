using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracja1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_CreatedById",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_CreatedById",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Exercise");
        }
    }
}
