using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioPlayer2.Migrations
{
    public partial class IsDownloadedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDownlouded",
                table: "Audios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDownlouded",
                table: "Audios");
        }
    }
}
