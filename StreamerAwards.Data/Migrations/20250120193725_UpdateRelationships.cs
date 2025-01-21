using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamerAwards.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "StreamerId",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CategoryId",
                table: "Votes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_StreamerId",
                table: "Votes",
                column: "StreamerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Streamers_StreamerId",
                table: "Votes",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Streamers_StreamerId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_CategoryId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_StreamerId",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "StreamerId",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
