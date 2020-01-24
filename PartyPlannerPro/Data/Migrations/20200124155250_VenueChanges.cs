using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class VenueChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Venues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "292a9e52-efeb-467e-b9e5-042698503485", "AQAAAAEAACcQAAAAELztym3jcY8twY6IKK90dAdWbIvFofct6L0ppEgyNk4ClfDqxtTppgKYHQdMr1qtPg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Venues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc6d7c8d-ded6-4a10-a1c8-b9511062270b", "AQAAAAEAACcQAAAAEEyuh/ebJo036CXeGyI1v2q6Rkr0OM+jNwdnZ7s9wfia05VkMOs+2K80klmFjRuk0Q==" });
        }
    }
}
