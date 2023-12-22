using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week4.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialno3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HealthStatuses",
                columns: new[] { "Id", "Allergies", "BehaviorChanges", "CheckupDate", "ChronicConditions", "Diagnosis", "Medications", "PetId", "Symptoms", "TreatmentNotes", "VaccinationRecord", "VaccinationStatus" },
                values: new object[,]
                {
                    { 4, "Süt ürünleri", "Huzursuzluk", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mide rahatsızlığı", "Gastrit", "Mide koruyucu", 3, "Bulantı", "Diyet ve mide koruyucu", "", 3 },
                    { 5, "Süt ürünleri", "Huzursuzluk", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mide rahatsızlığı", "Gastrit", "Mide koruyucu", 3, "Mide Sancısı", "Diyet ve mide koruyucu", "", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HealthStatuses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
