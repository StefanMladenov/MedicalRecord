using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class stefanaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HealthInsuranceNumber",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HealthInsuranceNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
