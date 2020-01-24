using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class FixViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd838593-ee4d-4fdc-ae05-f3dfbb726792", "AQAAAAEAACcQAAAAEEuB5KeFIfNDLIik368AlrnbhkmTJDx91C6uM2NXzzjOo/JOwMKmrbCjLscPweDYKw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e06f7c0d-8a1a-4fc6-9c01-3048f362df9e", "AQAAAAEAACcQAAAAECJQ5zpx9JPKOAmuckLj5/9wA9oyxeYMXxv+BjMDED2TPWdleopWZPCiZ26yGCrbSA==" });
        }
    }
}
