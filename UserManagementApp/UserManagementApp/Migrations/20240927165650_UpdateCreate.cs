using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLoginTime",
                table: "AspNetUsers",
                newName: "RegistrationTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationTime",
                table: "AspNetUsers",
                newName: "LastLoginTime");
        }
    }
}
