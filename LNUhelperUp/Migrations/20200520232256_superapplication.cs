using Microsoft.EntityFrameworkCore.Migrations;

namespace LNUhelperUp.Migrations
{
    public partial class superapplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Image_ImageId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_ImageId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Events",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Images_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_ImageId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageId",
                table: "Events",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Image_ImageId",
                table: "Events",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
