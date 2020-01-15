using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamneze",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioEpidemioloskiStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KartoniAlergena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hrana = table.Column<string>(nullable: true),
                    Ostalo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartoniAlergena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KartoniVakcinacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartoniVakcinacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ImeOca = table.Column<string>(nullable: true),
                    ImeMajke = table.Column<string>(nullable: true),
                    Pol = table.Column<int>(nullable: false),
                    LBO = table.Column<int>(nullable: false),
                    VidOsiguranja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ustanove",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ustanove", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bolesti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraBolesti = table.Column<string>(nullable: true),
                    NazivBolesti = table.Column<string>(nullable: true),
                    Terapija = table.Column<string>(nullable: true),
                    BolestDiskriminator = table.Column<int>(nullable: false),
                    AnamnezaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolesti_Anamneze_AnamnezaId",
                        column: x => x.AnamnezaId,
                        principalTable: "Anamneze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lekovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeLeka = table.Column<string>(nullable: true),
                    Alergican = table.Column<bool>(nullable: false),
                    KartonAlergenaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekovi_KartoniAlergena_KartonAlergenaId",
                        column: x => x.KartonAlergenaId,
                        principalTable: "KartoniAlergena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vakcine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeVakcine = table.Column<string>(nullable: true),
                    Trajanje = table.Column<int>(nullable: false),
                    DatumVakcinacije = table.Column<DateTime>(nullable: false),
                    KartonVakcinacijeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakcine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vakcine_KartoniVakcinacije_KartonVakcinacijeId",
                        column: x => x.KartonVakcinacijeId,
                        principalTable: "KartoniVakcinacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lekari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Specijalizacija = table.Column<string>(nullable: true),
                    UstanovaId = table.Column<int>(nullable: true),
                    BrFaksimila = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekari_Ustanove_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EKartoni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LekarId = table.Column<int>(nullable: true),
                    PacijentId = table.Column<int>(nullable: true),
                    KartonOcaId = table.Column<int>(nullable: true),
                    KartonMajkeId = table.Column<int>(nullable: true),
                    KartonAlergenaId = table.Column<int>(nullable: true),
                    KartonVakcinacijeId = table.Column<int>(nullable: true),
                    AnamnezaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EKartoni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EKartoni_Anamneze_AnamnezaId",
                        column: x => x.AnamnezaId,
                        principalTable: "Anamneze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_KartoniAlergena_KartonAlergenaId",
                        column: x => x.KartonAlergenaId,
                        principalTable: "KartoniAlergena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_EKartoni_KartonMajkeId",
                        column: x => x.KartonMajkeId,
                        principalTable: "EKartoni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_EKartoni_KartonOcaId",
                        column: x => x.KartonOcaId,
                        principalTable: "EKartoni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_KartoniVakcinacije_KartonVakcinacijeId",
                        column: x => x.KartonVakcinacijeId,
                        principalTable: "KartoniVakcinacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_Lekari_LekarId",
                        column: x => x.LekarId,
                        principalTable: "Lekari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKartoni_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PregledEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    EKartonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregledEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregledEntity_EKartoni_EKartonId",
                        column: x => x.EKartonId,
                        principalTable: "EKartoni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    TipSlike = table.Column<string>(nullable: true),
                    EKartonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slike_EKartoni_EKartonId",
                        column: x => x.EKartonId,
                        principalTable: "EKartoni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolesti_AnamnezaId",
                table: "Bolesti",
                column: "AnamnezaId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_AnamnezaId",
                table: "EKartoni",
                column: "AnamnezaId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_KartonAlergenaId",
                table: "EKartoni",
                column: "KartonAlergenaId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_KartonMajkeId",
                table: "EKartoni",
                column: "KartonMajkeId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_KartonOcaId",
                table: "EKartoni",
                column: "KartonOcaId",
                unique: true,
                filter: "[KartonOcaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_KartonVakcinacijeId",
                table: "EKartoni",
                column: "KartonVakcinacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_LekarId",
                table: "EKartoni",
                column: "LekarId");

            migrationBuilder.CreateIndex(
                name: "IX_EKartoni_PacijentId",
                table: "EKartoni",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekari_UstanovaId",
                table: "Lekari",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekovi_KartonAlergenaId",
                table: "Lekovi",
                column: "KartonAlergenaId");

            migrationBuilder.CreateIndex(
                name: "IX_PregledEntity_EKartonId",
                table: "PregledEntity",
                column: "EKartonId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_EKartonId",
                table: "Slike",
                column: "EKartonId");

            migrationBuilder.CreateIndex(
                name: "IX_Vakcine_KartonVakcinacijeId",
                table: "Vakcine",
                column: "KartonVakcinacijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bolesti");

            migrationBuilder.DropTable(
                name: "Lekovi");

            migrationBuilder.DropTable(
                name: "PregledEntity");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Vakcine");

            migrationBuilder.DropTable(
                name: "EKartoni");

            migrationBuilder.DropTable(
                name: "Anamneze");

            migrationBuilder.DropTable(
                name: "KartoniAlergena");

            migrationBuilder.DropTable(
                name: "KartoniVakcinacije");

            migrationBuilder.DropTable(
                name: "Lekari");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Ustanove");
        }
    }
}
