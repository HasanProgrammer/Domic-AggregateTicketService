using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domic.Persistence.Migrations.Q
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryQuery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryQuery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfRetry = table.Column<int>(type: "int", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserQuery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_CategoryQuery_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryQuery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_UserQuery_UserId",
                        column: x => x.UserId,
                        principalTable: "UserQuery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id_IsDeleted",
                table: "Tickets",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerEvents");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CategoryQuery");

            migrationBuilder.DropTable(
                name: "UserQuery");
        }
    }
}
