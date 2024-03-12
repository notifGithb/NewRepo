using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BildirimTestApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class mig_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SisBildirimIcerik",
                columns: table => new
                {
                    BildirimIcerikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Json = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    OlusturulanTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SisBildirimIcerik", x => x.BildirimIcerikId);
                });

            migrationBuilder.CreateTable(
                name: "SisKullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KullaniciSifresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SisKullanici", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "SisBildirim",
                columns: table => new
                {
                    BildirimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderilecekKullaniciId = table.Column<int>(type: "int", nullable: false),
                    GonderimDurumu = table.Column<int>(type: "int", nullable: false),
                    BildirimIcerikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SisBildirim", x => x.BildirimId);
                    table.ForeignKey(
                        name: "FK_SisBildirim_SisBildirimIcerik",
                        column: x => x.BildirimIcerikId,
                        principalTable: "SisBildirimIcerik",
                        principalColumn: "BildirimIcerikId");
                    table.ForeignKey(
                        name: "FK_SisBildirim_SisKullanici",
                        column: x => x.GonderilecekKullaniciId,
                        principalTable: "SisKullanici",
                        principalColumn: "KullaniciId");
                });

            migrationBuilder.CreateTable(
                name: "SisBildirimOutbox",
                columns: table => new
                {
                    BildirimOutboxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderimDenemeSayisi = table.Column<int>(type: "int", nullable: false),
                    BildirimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SisBildirimOutbox", x => x.BildirimOutboxId);
                    table.ForeignKey(
                        name: "FK_SisBildirimOutbox_SisBildirim",
                        column: x => x.BildirimId,
                        principalTable: "SisBildirim",
                        principalColumn: "BildirimId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SisBildirim_BildirimIcerikId",
                table: "SisBildirim",
                column: "BildirimIcerikId");

            migrationBuilder.CreateIndex(
                name: "IX_SisBildirim_GonderilecekKullaniciId",
                table: "SisBildirim",
                column: "GonderilecekKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_SisBildirimOutbox_BildirimId",
                table: "SisBildirimOutbox",
                column: "BildirimId");

            migrationBuilder.CreateIndex(
                name: "UK_SisKullanici",
                table: "SisKullanici",
                column: "KullaniciAdi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SisBildirimOutbox");

            migrationBuilder.DropTable(
                name: "SisBildirim");

            migrationBuilder.DropTable(
                name: "SisBildirimIcerik");

            migrationBuilder.DropTable(
                name: "SisKullanici");
        }
    }
}
