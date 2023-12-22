using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week4.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List<string>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnergyValue = table.Column<int>(type: "int", nullable: false),
                    NutritionalValues = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PortionSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServingFrequency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suitability = table.Column<string>(type: "text", nullable: false),
                    IsOrganic = table.Column<bool>(type: "bit", nullable: false),
                    IsContainsGluten = table.Column<bool>(type: "bit", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symptoms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ChronicConditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BehaviorChanges = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TreatmentNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VaccinationStatus = table.Column<int>(type: "int", nullable: false),
                    VaccinationRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CheckupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthStatuses_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Gender", "Name", "Password", "PhoneNumber", "RegistrationDate", "UserName" },
                values: new object[,]
                {
                    { 1, 30, "johndoe@example.com", "Male", "John Doe", "johndoe123", "1234567890", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe" },
                    { 2, 28, "janedoe@example.com", "Female", "Jane Doe", "janedoe123", "0987654321", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe" },
                    { 3, 35, "chrissmith@example.com", "Male", "Chris Smith", "chrissmith123", "1122334455", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chrissmith" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Breed", "Gender", "Name", "RegistrationDate", "Species", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 5, "Golden Retriever", "Erkek", "Max", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Köpek", 1, 30.0m },
                    { 2, 3, "Siamese", "Dişi", "Mia", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kedi", 1, 5.0m },
                    { 3, 2, "Beagle", "Erkek", "Charlie", new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Köpek", 2, 10.0m }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityType", "Description", "Effect", "EndTime", "PetId", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, 0, "Sabah yürüyüşü", 0, new DateTime(2021, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 1, "Bahçede oyun oynama", 1, new DateTime(2021, 10, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 10, 2, 15, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 2, "Temel itaat eğitimi", 3, new DateTime(2021, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "EnergyValue", "IsContainsGluten", "IsOrganic", "Name", "NutritionalValues", "PetId", "PortionSize", "ServingFrequency", "Suitability", "Type" },
                values: new object[,]
                {
                    { 1, 350, false, true, "Premium Kuru Mama", "Yüksek protein, düşük yağ", 1, 100m, "Günde iki kez", "{\"Köpek\":\"Yetişkin\"}", "kuru mama" },
                    { 2, 200, true, true, "Organik Yaş Mama", "Organik tavuk ve sebze", 2, 150m, "Günde üç kez", "{\"Kedi\":\"Yetişkin\"}", "yaş mama" },
                    { 3, 100, false, false, "Sağlıklı Ödül Maması", "Doğal malzemeler, ilave şeker içermez", 3, 50m, "Eğitim sırasında", "{\"Köpek\":\"Her yaştan\",\"Kedi\":\"Her yaştan\"}", "ödül maması" }
                });

            migrationBuilder.InsertData(
                table: "HealthStatuses",
                columns: new[] { "Id", "Allergies", "BehaviorChanges", "CheckupDate", "ChronicConditions", "Diagnosis", "Medications", "PetId", "Symptoms", "TreatmentNotes", "VaccinationRecord", "VaccinationStatus" },
                values: new object[,]
                {
                    { 1, "Polen", "Daha az aktif", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Astım", "Bronşit", "Bronşit ilacı", 1, "Öksürük, halsizlik", "İlaç ve dinlenme", "Karma,Kuduz", 2 },
                    { 2, "Yok", "Daha az yeme", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şeker hastalığı", "Diyabet", "İnsülin", 2, "İştahsızlık, kilo kaybı", "Diyet ve insülin", "Karma", 1 },
                    { 3, "Süt ürünleri", "Huzursuzluk", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mide rahatsızlığı", "Gastrit", "Mide koruyucu", 3, "Kusma, ishal", "Diyet ve mide koruyucu", "", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PetId",
                table: "Activities",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PetId",
                table: "Foods",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthStatuses_PetId",
                table: "HealthStatuses",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "HealthStatuses");

            migrationBuilder.DropTable(
                name: "List<string>");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
