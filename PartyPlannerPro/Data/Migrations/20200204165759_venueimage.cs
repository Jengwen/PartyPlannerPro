using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class venueimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Venues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef1e90c0-9ad3-4361-ab1b-5d51f9590c73", "AQAAAAEAACcQAAAAEKQk7qpujWu4aDUpSP2iqXqqTCdOEkpPEI2ASMkKOX9/MqJw7bSORBzhOFHl5YWxlA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Venues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "830afd15-4145-41d4-bf4c-66f91518e6d7", "AQAAAAEAACcQAAAAEPOEMzQbqzmzVPjjHqp5FQv8XtvHBhcja3HsfZwnqo/QEVEIhFIv4CSjgbqShCtjMw==" });
        }
    }
}
