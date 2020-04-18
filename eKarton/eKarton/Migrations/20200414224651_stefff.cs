using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class stefff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnapshotType",
                table: "Analysis");

            migrationBuilder.AddColumn<int>(
                name: "AnalysisType",
                table: "Analysis",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisType",
                table: "Analysis");

            migrationBuilder.AddColumn<int>(
                name: "SnapshotType",
                table: "Analysis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
