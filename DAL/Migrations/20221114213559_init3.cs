using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CupboardModelEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupboardModelEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CupboardEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupboardEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CupboardEntities_CupboardModelEntities_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CupboardModelEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CupboardClothesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CupboardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClothesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupboardClothesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CupboardClothesEntities_ClothesEntities_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "ClothesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CupboardClothesEntities_CupboardEntities_CupboardId",
                        column: x => x.CupboardId,
                        principalTable: "CupboardEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CupboardClothesEntities_ClothesId",
                table: "CupboardClothesEntities",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_CupboardClothesEntities_CupboardId",
                table: "CupboardClothesEntities",
                column: "CupboardId");

            migrationBuilder.CreateIndex(
                name: "IX_CupboardEntities_ModelId",
                table: "CupboardEntities",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CupboardClothesEntities");

            migrationBuilder.DropTable(
                name: "ClothesEntities");

            migrationBuilder.DropTable(
                name: "CupboardEntities");

            migrationBuilder.DropTable(
                name: "CupboardModelEntities");
        }
    }
}
