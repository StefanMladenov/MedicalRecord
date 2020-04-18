using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class sssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Institutes_InstituteGuid",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Institutes_InstituteGuid",
                table: "Instructions");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_InstituteGuid",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_InstituteGuid",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InstituteGuid",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "InstituteGuid",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstituteGuid",
                table: "Instructions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstituteGuid",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Guid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_InstituteGuid",
                table: "Instructions",
                column: "InstituteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_InstituteGuid",
                table: "Doctors",
                column: "InstituteGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Institutes_InstituteGuid",
                table: "Doctors",
                column: "InstituteGuid",
                principalTable: "Institutes",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Institutes_InstituteGuid",
                table: "Instructions",
                column: "InstituteGuid",
                principalTable: "Institutes",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
