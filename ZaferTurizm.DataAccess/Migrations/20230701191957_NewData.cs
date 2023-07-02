using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HumanInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kimlik = table.Column<string>(type: "varchar(15)", nullable: false),
                    BirhtDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GidisId = table.Column<int>(type: "int", nullable: false),
                    DonusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rota_Provinces_DonusId",
                        column: x => x.DonusId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rota_Provinces_GidisId",
                        column: x => x.GidisId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    VehicleMakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleMake_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDefintion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    HasTailet = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDefintion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDefintion_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OtobusSefer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RotaId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    VehicleDefintionId = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtobusSefer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtobusSefer_Rota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "Rota",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtobusSefer_VehicleDefintion_VehicleDefintionId",
                        column: x => x.VehicleDefintionId,
                        principalTable: "VehicleDefintion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleDefintionId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleDefintion_VehicleDefintionId",
                        column: x => x.VehicleDefintionId,
                        principalTable: "VehicleDefintion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumanId = table.Column<int>(type: "int", nullable: false),
                    SeferId = table.Column<int>(type: "int", nullable: false),
                    KoltukNumarası = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    SeferNumara = table.Column<int>(type: "int", nullable: false),
                    VerildigiTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilet_HumanInformation_HumanId",
                        column: x => x.HumanId,
                        principalTable: "HumanInformation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bilet_OtobusSefer_SeferId",
                        column: x => x.SeferId,
                        principalTable: "OtobusSefer",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyon" },
                    { 4, "Ağrı" },
                    { 5, "Aksaray" },
                    { 6, "Amasya" },
                    { 7, "Ankara" },
                    { 8, "Antalya" },
                    { 9, "Ardahan" },
                    { 10, "Artvin" },
                    { 11, "Aydın" },
                    { 12, "Balıkesir" },
                    { 13, "Bartın" },
                    { 14, "Batman" },
                    { 15, "Bayburt" },
                    { 16, "Bilecik" },
                    { 17, "Bingöl" },
                    { 18, "Bitlis" },
                    { 19, "Bolu" },
                    { 20, "Burdur" },
                    { 21, "Bursa" },
                    { 22, "Çanakkale" },
                    { 23, "Çankırı" },
                    { 24, "Çorum" },
                    { 25, "Denizli" },
                    { 26, "Diyarbakır" },
                    { 27, "Düzce" },
                    { 28, "Edirne" },
                    { 29, "Elazığ" },
                    { 30, "Erzincan" },
                    { 31, "Erzurum" },
                    { 32, "Eskişehir" },
                    { 33, "Gaziantep" },
                    { 34, "Giresun" },
                    { 35, "Gümüşhane" },
                    { 36, "Hakkari" },
                    { 37, "Hatay" },
                    { 38, "Iğdır" },
                    { 39, "Isparta" },
                    { 40, "İstanbul" },
                    { 41, "İzmir" },
                    { 42, "Kahramanmaraş" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 43, "Karabük" },
                    { 44, "Karaman" },
                    { 45, "Kars" },
                    { 46, "Kastamonu" },
                    { 47, "Kayseri" },
                    { 48, "Kırıkkale" },
                    { 49, "Kırklareli" },
                    { 50, "Kırşehir" },
                    { 51, "Kilis" },
                    { 52, "Kocaeli" },
                    { 53, "Konya" },
                    { 54, "Kütahya" },
                    { 55, "Malatya" },
                    { 56, "Manisa" },
                    { 57, "Mardin" },
                    { 58, "Mersin" },
                    { 59, "Muğla" },
                    { 60, "Muş" },
                    { 61, "Nevşehir" },
                    { 62, "Niğde" },
                    { 63, "Ordu" },
                    { 64, "Osmaniye" },
                    { 65, "Rize" },
                    { 66, "Sakarya" },
                    { 67, "Samsun" },
                    { 68, "Siirt" },
                    { 69, "Sinop" },
                    { 70, "Sivas" },
                    { 71, "Şanlıurfa" },
                    { 72, "Şırnak" },
                    { 73, "Tekirdağ" },
                    { 74, "Tokat" },
                    { 75, "Trabzon" },
                    { 76, "Tunceli" },
                    { 77, "Uşak" },
                    { 78, "Van" },
                    { 79, "Yalova" },
                    { 80, "Yozgat" },
                    { 81, "Zonguldak" }
                });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "MAN" },
                    { 3, "Neoplan" }
                });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Otokar" });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Volvo" });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 1, "Travego", 1 },
                    { 2, "403", 1 },
                    { 3, "Tourismo", 1 },
                    { 4, "Lions", 2 },
                    { 5, "Fortuna", 2 },
                    { 6, "SL", 2 }
                });

            migrationBuilder.InsertData(
                table: "VehicleDefintion",
                columns: new[] { "Id", "HasTailet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 1, false, true, 48, 1, 2020 });

            migrationBuilder.InsertData(
                table: "VehicleDefintion",
                columns: new[] { "Id", "HasTailet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 2, false, true, 48, 1, 2021 });

            migrationBuilder.InsertData(
                table: "VehicleDefintion",
                columns: new[] { "Id", "HasTailet", "HasWifi", "SeatCount", "VehicleModelId", "Year" },
                values: new object[] { 3, false, false, 52, 5, 2019 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "VehicleDefintionId" },
                values: new object[,]
                {
                    { 1, "34 ABC 123", 1 },
                    { 2, "34 CDE 654", 1 },
                    { 3, "34 QWE 345", 2 },
                    { 4, "34 ZXC 987", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_HumanId",
                table: "Bilet",
                column: "HumanId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_SeferId",
                table: "Bilet",
                column: "SeferId");

            migrationBuilder.CreateIndex(
                name: "IX_OtobusSefer_RotaId",
                table: "OtobusSefer",
                column: "RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_OtobusSefer_VehicleDefintionId",
                table: "OtobusSefer",
                column: "VehicleDefintionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_DonusId",
                table: "Rota",
                column: "DonusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_GidisId",
                table: "Rota",
                column: "GidisId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleDefintionId",
                table: "Vehicle",
                column: "VehicleDefintionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDefintion_VehicleModelId",
                table: "VehicleDefintion",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleMakeId",
                table: "VehicleModel",
                column: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "HumanInformation");

            migrationBuilder.DropTable(
                name: "OtobusSefer");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropTable(
                name: "VehicleDefintion");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleMake");
        }
    }
}
