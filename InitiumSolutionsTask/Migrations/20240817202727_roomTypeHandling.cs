using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitiumSolutionsTask.Migrations
{
    /// <inheritdoc />
    public partial class roomTypeHandling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "RoomBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RoomBookings",
                keyColumn: "RoomBookingId",
                keyValue: 1,
                column: "RoomTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomBookings",
                keyColumn: "RoomBookingId",
                keyValue: 2,
                column: "RoomTypeId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_RoomTypeId",
                table: "RoomBookings",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_RoomTypes_RoomTypeId",
                table: "RoomBookings",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_RoomTypes_RoomTypeId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_RoomTypeId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "RoomBookings");
        }
    }
}
