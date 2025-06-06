using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_comp_user_id_comp",
                table: "comp_user",
                column: "id_comp");

            migrationBuilder.CreateIndex(
                name: "IX_comp_user_id_user",
                table: "comp_user",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_comp_user_competition_id_comp",
                table: "comp_user",
                column: "id_comp",
                principalTable: "competition",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comp_user_users_id_user",
                table: "comp_user",
                column: "id_user",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comp_user_competition_id_comp",
                table: "comp_user");

            migrationBuilder.DropForeignKey(
                name: "FK_comp_user_users_id_user",
                table: "comp_user");

            migrationBuilder.DropIndex(
                name: "IX_comp_user_id_comp",
                table: "comp_user");

            migrationBuilder.DropIndex(
                name: "IX_comp_user_id_user",
                table: "comp_user");
        }
    }
}
