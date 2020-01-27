using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class EventVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd3f14cb-6861-41a0-a6db-4d57d2fedab9", "AQAAAAEAACcQAAAAEK8wahj7x3mG4iFgIdWS1EOhd0Knh19Tp2SNag8KprZ6kfoZAPcUJg+vFzK0dDB/ZA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5d76eea-7e6f-43e8-8d9d-063bf559a252", "AQAAAAEAACcQAAAAEDTXHAhnVV/AYJyqcvE78x8UEJBbV2tjZtvz0tHqnZ/2MojAijhN0ootLOPwd0J3Dg==" });
        }
    }
}
