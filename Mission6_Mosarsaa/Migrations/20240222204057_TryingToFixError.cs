using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission6_Mosarsaa.Migrations
{
    /// <inheritdoc />
    public partial class TryingToFixError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "LentTo",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Movies",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
