using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccess.Migrations
{
    public partial class AddEmployee3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_AuthUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AuthUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AuthUserId",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AuthUserId",
                table: "Employee",
                column: "AuthUserId",
                unique: true,
                filter: "[AuthUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_AuthUserId",
                table: "Employee",
                column: "AuthUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
