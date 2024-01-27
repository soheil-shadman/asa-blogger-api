using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsaBloggerApi.Migrations
{
    /// <inheritdoc />
    public partial class Usertoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "user");
        }
    }
}
