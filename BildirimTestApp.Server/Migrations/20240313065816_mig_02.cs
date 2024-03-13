using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BildirimTestApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class mig_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GorevId",
                table: "SisKullanici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Gorevs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorevId",
                table: "SisKullanici");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Gorevs");
        }
    }
}
