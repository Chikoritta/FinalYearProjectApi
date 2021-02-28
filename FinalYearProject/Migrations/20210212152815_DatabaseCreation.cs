using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donation_status",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donation_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    target = table.Column<long>(nullable: false),
                    current_collected = table.Column<long>(nullable: false),
                    receipt_url = table.Column<string>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.id);
                    table.ForeignKey(
                        name: "FK_donations_donation_status_status_id",
                        column: x => x.status_id,
                        principalTable: "donation_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    birth_date = table.Column<DateTime>(nullable: false),
                    mobile_number = table.Column<string>(nullable: true),
                    longitude = table.Column<double>(nullable: false),
                    latitude = table.Column<double>(nullable: false),
                    avatar_url = table.Column<string>(nullable: true),
                    gender_type_id = table.Column<long>(nullable: true),
                    user_type_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_gender_gender_type_id",
                        column: x => x.gender_type_id,
                        principalTable: "gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_users_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "user_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "user_donation",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sponsor_id = table.Column<long>(nullable: false),
                    donation_id = table.Column<long>(nullable: false),
                    amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_donation", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_donation_donations_donation_id",
                        column: x => x.donation_id,
                        principalTable: "donations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_user_donation_users_sponsor_id",
                        column: x => x.sponsor_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donations_status_id",
                table: "donations",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_donation_donation_id",
                table: "user_donation",
                column: "donation_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_donation_sponsor_id",
                table: "user_donation",
                column: "sponsor_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_gender_type_id",
                table: "users",
                column: "gender_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_type_id",
                table: "users",
                column: "user_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_donation");

            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "donation_status");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "user_type");
        }
    }
}
