using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class changevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Venues");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Venues",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1720fe1-bf57-4d52-8b71-4d4becb57431", "AQAAAAEAACcQAAAAECPXRCUrHS5Xc0hC5IkuyFL1R5DZVL0FsVviUDVllRfeUd6Q6yBgk0KLUzgqttPZJg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Venues");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "daafb373-adf1-4140-b1a9-96d7be9f3339", "AQAAAAEAACcQAAAAEMRSn3UDZ24+4h5I+bFY3ThNvL8Q24zGjsgIfH1Tyr+GGyDkpR6uldDOl2VBdT/qQw==" });
        }
    }
}
