using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BildirimTestApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class mig_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GorevSisKullanici_Gorevs_GorevsGorevId",
                table: "GorevSisKullanici");

            migrationBuilder.DropForeignKey(
                name: "FK_GorevSisKullanici_SisKullanici_SisKullanicisKullaniciId",
                table: "GorevSisKullanici");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GorevSisKullanici",
                table: "GorevSisKullanici");

            migrationBuilder.RenameTable(
                name: "GorevSisKullanici",
                newName: "SisKullaniciGorevs");

            migrationBuilder.RenameIndex(
                name: "IX_GorevSisKullanici_SisKullanicisKullaniciId",
                table: "SisKullaniciGorevs",
                newName: "IX_SisKullaniciGorevs_SisKullanicisKullaniciId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SisKullaniciGorevs",
                table: "SisKullaniciGorevs",
                columns: new[] { "GorevsGorevId", "SisKullanicisKullaniciId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SisKullaniciGorevs_Gorevs_GorevsGorevId",
                table: "SisKullaniciGorevs",
                column: "GorevsGorevId",
                principalTable: "Gorevs",
                principalColumn: "GorevId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SisKullaniciGorevs_SisKullanici_SisKullanicisKullaniciId",
                table: "SisKullaniciGorevs",
                column: "SisKullanicisKullaniciId",
                principalTable: "SisKullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SisKullaniciGorevs_Gorevs_GorevsGorevId",
                table: "SisKullaniciGorevs");

            migrationBuilder.DropForeignKey(
                name: "FK_SisKullaniciGorevs_SisKullanici_SisKullanicisKullaniciId",
                table: "SisKullaniciGorevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SisKullaniciGorevs",
                table: "SisKullaniciGorevs");

            migrationBuilder.RenameTable(
                name: "SisKullaniciGorevs",
                newName: "GorevSisKullanici");

            migrationBuilder.RenameIndex(
                name: "IX_SisKullaniciGorevs_SisKullanicisKullaniciId",
                table: "GorevSisKullanici",
                newName: "IX_GorevSisKullanici_SisKullanicisKullaniciId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GorevSisKullanici",
                table: "GorevSisKullanici",
                columns: new[] { "GorevsGorevId", "SisKullanicisKullaniciId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GorevSisKullanici_Gorevs_GorevsGorevId",
                table: "GorevSisKullanici",
                column: "GorevsGorevId",
                principalTable: "Gorevs",
                principalColumn: "GorevId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GorevSisKullanici_SisKullanici_SisKullanicisKullaniciId",
                table: "GorevSisKullanici",
                column: "SisKullanicisKullaniciId",
                principalTable: "SisKullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
