using Microsoft.EntityFrameworkCore.Migrations;

namespace LNUhelperUp.Migrations
{
    public partial class NamingAndNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Events",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantAmount",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Announcements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ParticipantAmount",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Announcements");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Events",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
