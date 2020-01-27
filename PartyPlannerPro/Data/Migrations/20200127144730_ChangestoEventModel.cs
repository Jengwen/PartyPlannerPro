using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class ChangestoEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5d76eea-7e6f-43e8-8d9d-063bf559a252", "AQAAAAEAACcQAAAAEDTXHAhnVV/AYJyqcvE78x8UEJBbV2tjZtvz0tHqnZ/2MojAijhN0ootLOPwd0J3Dg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd838593-ee4d-4fdc-ae05-f3dfbb726792", "AQAAAAEAACcQAAAAEEuB5KeFIfNDLIik368AlrnbhkmTJDx91C6uM2NXzzjOo/JOwMKmrbCjLscPweDYKw==" });
        }
    }
}
