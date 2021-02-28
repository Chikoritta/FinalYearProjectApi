using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Migrations
{
    public partial class ExtendedDonationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "admin_id",
                table: "donations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "orphan_id",
                table: "donations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_donations_admin_id",
                table: "donations",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_donations_orphan_id",
                table: "donations",
                column: "orphan_id");

            migrationBuilder.AddForeignKey(
                name: "FK_donations_users_admin_id",
                table: "donations",
                column: "admin_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_donations_users_orphan_id",
                table: "donations",
                column: "orphan_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donations_users_admin_id",
                table: "donations");

            migrationBuilder.DropForeignKey(
                name: "FK_donations_users_orphan_id",
                table: "donations");

            migrationBuilder.DropIndex(
                name: "IX_donations_admin_id",
                table: "donations");

            migrationBuilder.DropIndex(
                name: "IX_donations_orphan_id",
                table: "donations");

            migrationBuilder.DropColumn(
                name: "admin_id",
                table: "donations");

            migrationBuilder.DropColumn(
                name: "orphan_id",
                table: "donations");
        }
    }
}
