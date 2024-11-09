using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KashmiriTourister.Migrations
{
    /// <inheritdoc />
    public partial class Blogsmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    properties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blog = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
