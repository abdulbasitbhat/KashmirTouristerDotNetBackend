using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KashmiriTourister.Migrations
{
    /// <inheritdoc />
    public partial class certificate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "landmarkId",
                table: "CertificateRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "landmarkId",
                table: "CertificateRequest");
        }
    }
}
