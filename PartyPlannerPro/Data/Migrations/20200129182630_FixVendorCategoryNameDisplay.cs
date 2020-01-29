using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyPlannerPro.Data.Migrations
{
    public partial class FixVendorCategoryNameDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "VendorCatergories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "830afd15-4145-41d4-bf4c-66f91518e6d7", "AQAAAAEAACcQAAAAEPOEMzQbqzmzVPjjHqp5FQv8XtvHBhcja3HsfZwnqo/QEVEIhFIv4CSjgbqShCtjMw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "VendorCatergories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "783015b5-f275-4e20-ad86-ef0f668aa882", "AQAAAAEAACcQAAAAEKalk06JNUuY2kcuLSDu1uLjO9zoIUK5rOXoHdOp+mEE5gcLwq5kGaJD6XjqJ3QaMA==" });
        }
    }
}
