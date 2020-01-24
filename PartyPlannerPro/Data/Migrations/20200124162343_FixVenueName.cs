using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class FixVenueName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "Venues");

            migrationBuilder.AddColumn<string>(
                name: "VenueName",
                table: "Venues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88359862-92af-4d40-bca5-e0f90ba28f75", "AQAAAAEAACcQAAAAEEzpiOu/3dKRrI2pIgPS+j8s+n3ifJyqEdwQWkTIQ0sqzmCaduROThEdvRB+C5n/VQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenueName",
                table: "Venues");

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "292a9e52-efeb-467e-b9e5-042698503485", "AQAAAAEAACcQAAAAELztym3jcY8twY6IKK90dAdWbIvFofct6L0ppEgyNk4ClfDqxtTppgKYHQdMr1qtPg==" });
        }
    }
}
