using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class VendorCatUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21b578fe-ad7d-4bdc-a8e7-5e1387b2bfa1", "AQAAAAEAACcQAAAAEMByDGKu6mQpy8mbJlqkzZ8lBXzzZIRb4NmgfKrslaA+Kx4aozcrF5JXGN30GQ4//Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd3f14cb-6861-41a0-a6db-4d57d2fedab9", "AQAAAAEAACcQAAAAEK8wahj7x3mG4iFgIdWS1EOhd0Knh19Tp2SNag8KprZ6kfoZAPcUJg+vFzK0dDB/ZA==" });
        }
    }
}
