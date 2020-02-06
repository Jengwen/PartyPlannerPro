using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class vendorcategoryImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CategoryImage",
                table: "VendorCatergories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "daafb373-adf1-4140-b1a9-96d7be9f3339", "AQAAAAEAACcQAAAAEMRSn3UDZ24+4h5I+bFY3ThNvL8Q24zGjsgIfH1Tyr+GGyDkpR6uldDOl2VBdT/qQw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "VendorCatergories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c41da67d-ac7f-41dd-b792-bb28be21600c", "AQAAAAEAACcQAAAAEKFCZO7orbS1nOdwRyjpFZsEfP0JRtaoPfOvhiN8e/zm9AShHAPKkb4J851Mjw87ig==" });
        }
    }
}
