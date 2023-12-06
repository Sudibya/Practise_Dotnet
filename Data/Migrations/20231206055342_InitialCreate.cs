using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMaster",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMaster", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK_Module_RoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMaster",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfActivation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_RoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMaster",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeactiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_Program_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Program_RoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMaster",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_RoleId",
                table: "Module",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_ModuleID",
                table: "Program",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Program_RoleId",
                table: "Program",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "RoleMaster");
        }
    }
}
