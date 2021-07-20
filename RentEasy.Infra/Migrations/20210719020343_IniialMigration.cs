using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentEasy.Infra.Migrations
{
    public partial class IniialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Format = table.Column<string>(type: "varchar(20)", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                    table.ForeignKey(
                        name: "FK_House_Photo_PhotoId1",
                        column: x => x.PhotoId1,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_House_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    StatusPayment = table.Column<int>(type: "int", nullable: false),
                    StatusTenant = table.Column<int>(type: "int", nullable: false),
                    PayDay = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateExit = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_PhotoId1",
                table: "House",
                column: "PhotoId1");

            migrationBuilder.CreateIndex(
                name: "IX_House_ProfileId",
                table: "House",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_HouseId",
                table: "Photo",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdUser",
                table: "Profile",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_HouseId",
                table: "Tenant",
                column: "HouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_House_HouseId",
                table: "Photo",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Photo_PhotoId1",
                table: "House");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
