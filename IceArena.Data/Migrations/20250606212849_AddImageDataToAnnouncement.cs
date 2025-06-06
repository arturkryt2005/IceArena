using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageDataToAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mongo_image_id",
                table: "announcements");

            migrationBuilder.AddColumn<string>(
                name: "image_content_type",
                table: "announcements",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "image_data",
                table: "announcements",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_content_type",
                table: "announcements");

            migrationBuilder.DropColumn(
                name: "image_data",
                table: "announcements");

            migrationBuilder.AddColumn<string>(
                name: "mongo_image_id",
                table: "announcements",
                type: "text",
                nullable: true);
        }
    }
}
