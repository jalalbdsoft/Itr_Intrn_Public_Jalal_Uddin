using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomisableFormsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedCandidateUserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "USER_ID_CANDIDATE",
                table: "Templates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_USER_ID_CANDIDATE",
                table: "Templates",
                column: "USER_ID_CANDIDATE");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_AspNetUsers_USER_ID_CANDIDATE",
                table: "Templates",
                column: "USER_ID_CANDIDATE",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_AspNetUsers_USER_ID_CANDIDATE",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_USER_ID_CANDIDATE",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "USER_ID_CANDIDATE",
                table: "Templates");
        }
    }
}
