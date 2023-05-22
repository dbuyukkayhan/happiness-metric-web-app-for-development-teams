using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams",
                columns: new[] { "UserId", "TeamId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_RoleId",
                table: "UserTeams",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Role_RoleId",
                table: "UserTeams",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Role_RoleId",
                table: "UserTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserTeams_RoleId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserTeams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTeams",
                table: "UserTeams",
                columns: new[] { "UserId", "TeamId" });
        }
    }
}
