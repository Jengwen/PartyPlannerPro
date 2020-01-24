using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class FixVenueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e06f7c0d-8a1a-4fc6-9c01-3048f362df9e", "AQAAAAEAACcQAAAAECJQ5zpx9JPKOAmuckLj5/9wA9oyxeYMXxv+BjMDED2TPWdleopWZPCiZ26yGCrbSA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88359862-92af-4d40-bca5-e0f90ba28f75", "AQAAAAEAACcQAAAAEEzpiOu/3dKRrI2pIgPS+j8s+n3ifJyqEdwQWkTIQ0sqzmCaduROThEdvRB+C5n/VQ==" });
        }
    }
}
