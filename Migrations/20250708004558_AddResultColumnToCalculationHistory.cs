using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XCalc.Migrations
{
    /// <inheritdoc />
    public partial class AddResultColumnToCalculationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Result",
                table: "CalculationHistories",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "CalculationHistories");
        }
    }
}
