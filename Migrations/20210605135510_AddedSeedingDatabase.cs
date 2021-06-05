using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia6_zen_s19743.Migrations
{
    public partial class AddedSeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jan@kowalski.pl", "Jan", "Kowalski" },
                    { 2, "grzegorz@krychowiak.pl", "Grzegorz", "Krychowiak" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "This medicament treats some illness", "Medicament 1", "Type 1" },
                    { 2, "This medicament treats other illness", "Medicament 2", "Type 2" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthday", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paweł", "Nowak" },
                    { 2, new DateTime(1973, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marek", "Markowski" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2021, 6, 5, 15, 55, 9, 852, DateTimeKind.Local).AddTicks(5720), new DateTime(2021, 6, 6, 15, 55, 9, 852, DateTimeKind.Local).AddTicks(5762), 1, 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "Don't overdose", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);
        }
    }
}
