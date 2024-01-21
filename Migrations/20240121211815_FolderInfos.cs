using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComparerBasic.Migrations
{
    /// <inheritdoc />
    public partial class FolderInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolderInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FolderName = table.Column<string>(type: "text", nullable: false),
                    FolderStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolderInfos");
        }
    }
}
