using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCore.Services.Migrations
{
    public partial class AddingUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100", maxLength: 100, nullable: false),
                    UserEMail = table.Column<string>(type: "nvarchar(320", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(130", maxLength: 130, nullable: false),
                    IsMembershipWithdrawn = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    JoinedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RoleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RolePriority = table.Column<byte>(type: "tinyint", nullable: false),
                    ModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesByUser",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RoleID = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OwnedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesByUser", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRolesByUser_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesByUser_UserRole_RoleID",
                        column: x => x.RoleID,
                        principalTable: "UserRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserEMail",
                table: "User",
                column: "UserEMail");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesByUser_RoleID",
                table: "UserRolesByUser",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRolesByUser");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
