using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class ktg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KartoniAlergenaLista",
                columns: table => new
                {
                    KartonAlergenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartoniAlergenaLista", x => x.KartonAlergenaID);
                });

            migrationBuilder.CreateTable(
                name: "KartoniVakcinacijeLista",
                columns: table => new
                {
                    KartonVakcinacijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartoniVakcinacijeLista", x => x.KartonVakcinacijeID);
                });

            migrationBuilder.CreateTable(
                name: "OsobeLista",
                columns: table => new
                {
                    OsobaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Specijalizacija = table.Column<string>(nullable: true),
                    GodineRadnogStaza = table.Column<int>(nullable: true),
                    Ustanova = table.Column<string>(nullable: true),
                    Ordinacija = table.Column<string>(nullable: true),
                    BrFaksimila = table.Column<int>(nullable: true),
                    ImeOca = table.Column<string>(nullable: true),
                    ImeMajke = table.Column<string>(nullable: true),
                    KrvnaGrupa = table.Column<string>(nullable: true),
                    Tezina = table.Column<int>(nullable: true),
                    Visina = table.Column<int>(nullable: true),
                    LBO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobeLista", x => x.OsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Alergen",
                columns: table => new
                {
                    AlergenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeAlergena = table.Column<string>(nullable: true),
                    Alergican = table.Column<bool>(nullable: false),
                    KartonAlergenaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergen", x => x.AlergenID);
                    table.ForeignKey(
                        name: "FK_Alergen_KartoniAlergenaLista_KartonAlergenaID",
                        column: x => x.KartonAlergenaID,
                        principalTable: "KartoniAlergenaLista",
                        principalColumn: "KartonAlergenaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LekoviLista",
                columns: table => new
                {
                    LekID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeLeka = table.Column<string>(nullable: true),
                    Alergican = table.Column<bool>(nullable: false),
                    KartonAlergenaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekoviLista", x => x.LekID);
                    table.ForeignKey(
                        name: "FK_LekoviLista_KartoniAlergenaLista_KartonAlergenaID",
                        column: x => x.KartonAlergenaID,
                        principalTable: "KartoniAlergenaLista",
                        principalColumn: "KartonAlergenaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VakcineLista",
                columns: table => new
                {
                    VakcinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeVakcine = table.Column<string>(nullable: true),
                    Trajanje = table.Column<int>(nullable: false),
                    DatumVakcinacije = table.Column<DateTime>(nullable: false),
                    KartonVakcinacijeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VakcineLista", x => x.VakcinaID);
                    table.ForeignKey(
                        name: "FK_VakcineLista_KartoniVakcinacijeLista_KartonVakcinacijeID",
                        column: x => x.KartonVakcinacijeID,
                        principalTable: "KartoniVakcinacijeLista",
                        principalColumn: "KartonVakcinacijeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EKartoniLista",
                columns: table => new
                {
                    KartonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LekarOsobaID = table.Column<int>(nullable: true),
                    PacijentOsobaID = table.Column<int>(nullable: true),
                    KartonOcaKartonID = table.Column<int>(nullable: true),
                    KartonMajkeKartonID = table.Column<int>(nullable: true),
                    KartonAlergenaID = table.Column<int>(nullable: true),
                    KartonVakcinacijeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EKartoniLista", x => x.KartonID);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_KartoniAlergenaLista_KartonAlergenaID",
                        column: x => x.KartonAlergenaID,
                        principalTable: "KartoniAlergenaLista",
                        principalColumn: "KartonAlergenaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_EKartoniLista_KartonMajkeKartonID",
                        column: x => x.KartonMajkeKartonID,
                        principalTable: "EKartoniLista",
                        principalColumn: "KartonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_EKartoniLista_KartonOcaKartonID",
                        column: x => x.KartonOcaKartonID,
                        principalTable: "EKartoniLista",
                        principalColumn: "KartonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_KartoniVakcinacijeLista_KartonVakcinacijeID",
                        column: x => x.KartonVakcinacijeID,
                        principalTable: "KartoniVakcinacijeLista",
                        principalColumn: "KartonVakcinacijeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_OsobeLista_LekarOsobaID",
                        column: x => x.LekarOsobaID,
                        principalTable: "OsobeLista",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoniLista_OsobeLista_PacijentOsobaID",
                        column: x => x.PacijentOsobaID,
                        principalTable: "OsobeLista",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PregledEntity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    EKartonKartonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregledEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PregledEntity_EKartoniLista_EKartonKartonID",
                        column: x => x.EKartonKartonID,
                        principalTable: "EKartoniLista",
                        principalColumn: "KartonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlikeLista",
                columns: table => new
                {
                    SlikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    TipSlike = table.Column<string>(nullable: true),
                    EKartonKartonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikeLista", x => x.SlikaID);
                    table.ForeignKey(
                        name: "FK_SlikeLista_EKartoniLista_EKartonKartonID",
                        column: x => x.EKartonKartonID,
                        principalTable: "EKartoniLista",
                        principalColumn: "KartonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergen_KartonAlergenaID",
                table: "Alergen",
                column: "KartonAlergenaID");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_KartonAlergenaID",
                table: "EKartoniLista",
                column: "KartonAlergenaID");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_KartonMajkeKartonID",
                table: "EKartoniLista",
                column: "KartonMajkeKartonID");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_KartonOcaKartonID",
                table: "EKartoniLista",
                column: "KartonOcaKartonID",
                unique: true,
                filter: "[KartonOcaKartonID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_KartonVakcinacijeID",
                table: "EKartoniLista",
                column: "KartonVakcinacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_LekarOsobaID",
                table: "EKartoniLista",
                column: "LekarOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoniLista_PacijentOsobaID",
                table: "EKartoniLista",
                column: "PacijentOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_LekoviLista_KartonAlergenaID",
                table: "LekoviLista",
                column: "KartonAlergenaID");

            migrationBuilder.CreateIndex(
                name: "IX_PregledEntity_EKartonKartonID",
                table: "PregledEntity",
                column: "EKartonKartonID");

            migrationBuilder.CreateIndex(
                name: "IX_SlikeLista_EKartonKartonID",
                table: "SlikeLista",
                column: "EKartonKartonID");

            migrationBuilder.CreateIndex(
                name: "IX_VakcineLista_KartonVakcinacijeID",
                table: "VakcineLista",
                column: "KartonVakcinacijeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergen");

            migrationBuilder.DropTable(
                name: "LekoviLista");

            migrationBuilder.DropTable(
                name: "PregledEntity");

            migrationBuilder.DropTable(
                name: "SlikeLista");

            migrationBuilder.DropTable(
                name: "VakcineLista");

            migrationBuilder.DropTable(
                name: "EKartoniLista");

            migrationBuilder.DropTable(
                name: "KartoniAlergenaLista");

            migrationBuilder.DropTable(
                name: "KartoniVakcinacijeLista");

            migrationBuilder.DropTable(
                name: "OsobeLista");
        }
    }
}
