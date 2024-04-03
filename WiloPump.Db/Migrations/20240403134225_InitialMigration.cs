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
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
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
                    { new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "Прочный материал", "Чугун" }
                });

            migrationBuilder.InsertData(
                table: "Pumps",
                columns: new[] { "Id", "Description", "EngineId", "HousingMaterialId", "Image", "LiquidTemperature", "LmpellerMaterialId", "MaxPressure", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("1f9631b1-76cf-42f7-bd64-aee4386c9cad"), "Простой и надёжный циркуляционный насос с мокрым ротором.", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/12017849/560x504/154444745.jpg", "-10,+110", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), 10, "NOC 25/8 EM", 11495m, 3.0 },
                    { new Guid("28e9e46e-88bc-4751-af0e-a75980d4e489"), "Циркуляционный насос с мокрым ротором для установки в трубах с ручной трехступенчатой регулировкой частоты вращения.", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/13172509/560x504/160317907.jpg", "-10,+110", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), 10, "STAR-RS 25/6", 22010m, 3.2000000000000002 },
                    { new Guid("914e3db4-0c95-436d-a9e8-72a9d236bef7"), "Простой и надёжный циркуляционный насос с мокрым ротором.", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/12017891/560x504/154444973.jpg", "+110", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), 10, "NOC 50/16 DM", 81227m, 21.0 },
                    { new Guid("93a74c8a-0e56-4c2e-bbd1-8e8c362e8c3b"), "Высокоэффективный насос с электронной системой регулирования.", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/13016417/560x504/159541025.jpg", "+95", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), 10, "Yonos Pico 25/1-4", 26412m, 1.8 },
                    { new Guid("ed725738-d0e0-42e6-91c3-ba1fbae7f2ec"), "Циркуляционный насос для специализированных работ", new Guid("88de934e-46ac-41f6-b72a-9a7ceb398d18"), new Guid("d31c3852-9e03-4b8a-a518-e1d876118fae"), "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/8576907/560x504/99483939.jpg", "+110", new Guid("b6962658-3f60-4456-8df0-190e3b214204"), 10, "NOC 65/12 DM", 53053m, 24.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_EngineId",
                table: "Pumps",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_HousingMaterialId",
                table: "Pumps",
                column: "HousingMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_LmpellerMaterialId",
                table: "Pumps",
                column: "LmpellerMaterialId");
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
