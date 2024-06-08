using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Migrations
{
    public partial class ShippedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Musics_musicId",
                table: "CartLine");

            migrationBuilder.DropIndex(
                name: "IX_CartLine_musicId",
                table: "CartLine");

            migrationBuilder.DropColumn(
                name: "musicId",
                table: "CartLine");

            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "CartLine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_AlbumId",
                table: "CartLine",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Musics_AlbumId",
                table: "CartLine",
                column: "AlbumId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Musics_AlbumId",
                table: "CartLine");

            migrationBuilder.DropIndex(
                name: "IX_CartLine_AlbumId",
                table: "CartLine");

            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "CartLine");

            migrationBuilder.AddColumn<int>(
                name: "musicId",
                table: "CartLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_musicId",
                table: "CartLine",
                column: "musicId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Musics_musicId",
                table: "CartLine",
                column: "musicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
