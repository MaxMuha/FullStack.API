using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WiloPump.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<int>(type: "integer", nullable: false),
                    Amperage = table.Column<double>(type: "double precision", nullable: false),
                    RatedSpeed = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxPressure = table.Column<int>(type: "integer", nullable: false),
                    LiquidTemperature = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    LmpellerMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    EngineId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: true),
                    MaterialId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pumps_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pumps_Engines_EngineId1",
                        column: x => x.EngineId1,
                        principalTable: "Engines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pumps_Materials_HousingMaterialId",
                        column: x => x.HousingMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pumps_Materials_LmpellerMaterialId",
                        column: x => x.LmpellerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pumps_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pumps_Materials_MaterialId1",
                        column: x => x.MaterialId1,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Amperage", "Description", "Name", "Power", "Price", "RatedSpeed" },
                values: new object[] { new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), 16.899999999999999, "Электродвигатель", "Трехфазный", 3, 1590m, 2900 });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("b6962658-3f60-4456-8df0-190e3b214204"), "Материал колеса", "Материал колеса" },
                    { new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "Материал корпуса", "Материал корпуса" }
                });

            migrationBuilder.InsertData(
                table: "Pumps",
                columns: new[] { "Id", "Description", "EngineId", "EngineId1", "HousingMaterialId", "Image", "LiquidTemperature", "LmpellerMaterialId", "MaterialId", "MaterialId1", "MaxPressure", "Name", "Price", "Weight" },
                values: new object[] { new Guid("1f9631b1-76cf-42f7-bd64-aee4386c9cad"), "Трехскоростной циркуляционный насос", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), null, new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "Изображение", "-10,+110", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), null, null, 10, "NOC 25/8 EM", 13500m, 3.7999999999999998 });

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_EngineId",
                table: "Pumps",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_EngineId1",
                table: "Pumps",
                column: "EngineId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_HousingMaterialId",
                table: "Pumps",
                column: "HousingMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_LmpellerMaterialId",
                table: "Pumps",
                column: "LmpellerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_MaterialId",
                table: "Pumps",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_MaterialId1",
                table: "Pumps",
                column: "MaterialId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pumps");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
