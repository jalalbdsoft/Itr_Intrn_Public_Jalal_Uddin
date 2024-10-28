using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomisableFormsApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    USER_ID_CANDIDATE = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CUSTOM_STRING1_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING1_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING2_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING2_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING3_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING3_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING4_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING4_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING5_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING5_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING6_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING6_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING7_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING7_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING8_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING8_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING9_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING9_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING10_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING10_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING11_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING11_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING12_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING12_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING13_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING13_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING14_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING14_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING15_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING15_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING16_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING16_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING17_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING17_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING18_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING18_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING19_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING19_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING20_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING20_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING21_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING21_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING22_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING22_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING23_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING23_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING24_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING24_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING25_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING25_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING26_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING26_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING27_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING27_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING28_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING28_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING29_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING29_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING30_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING30_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING31_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING31_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING32_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING32_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING33_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING33_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING34_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING34_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING35_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING35_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING36_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING36_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING37_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING37_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING38_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING38_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING39_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING39_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING40_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING40_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING41_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING41_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING42_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING42_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING43_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING43_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING44_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING44_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING45_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING45_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING46_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING46_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING47_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING47_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING48_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING48_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING49_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING49_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING50_QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOM_STRING50_ANSWER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Templates_AspNetUsers_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Templates_AspNetUsers_USER_ID_CANDIDATE",
                        column: x => x.USER_ID_CANDIDATE,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_USER_ID",
                table: "Templates",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_USER_ID_CANDIDATE",
                table: "Templates",
                column: "USER_ID_CANDIDATE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
