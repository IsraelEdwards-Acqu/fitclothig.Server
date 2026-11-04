using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITClothing.API.Migrations
{
    /// <inheritdoc />
    public partial class HeroSlides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignElement");

            migrationBuilder.DropColumn(
                name: "BackDesignJson",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Designs");

            migrationBuilder.RenameColumn(
                name: "FrontDesignJson",
                table: "Designs",
                newName: "DesignJson");

            migrationBuilder.CreateTable(
                name: "HeroSlides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    ButtonText = table.Column<string>(type: "text", nullable: false),
                    ButtonLink = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSlides", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSlides");

            migrationBuilder.RenameColumn(
                name: "DesignJson",
                table: "Designs",
                newName: "FrontDesignJson");

            migrationBuilder.AddColumn<string>(
                name: "BackDesignJson",
                table: "Designs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Designs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Designs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DesignElement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DesignId = table.Column<Guid>(type: "uuid", nullable: true),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Rotation = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignElement_Designs_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Designs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesignElement_DesignId",
                table: "DesignElement",
                column: "DesignId");
        }
    }
}
