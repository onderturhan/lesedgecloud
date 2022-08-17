using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdgeCloud.LES.ClassLibrary.Repository.Migrations
{
    public partial class InitialCreate20220817 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiRequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RequestData = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ResponseData = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    ResponseDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ClientMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    ClientMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AuthActivityDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteractionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    InteractionActivityDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    NavigationActivityDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetworkLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    NetworkActivityDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServerImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiRequestLogs");

            migrationBuilder.DropTable(
                name: "AuthenticationLogs");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "InteractionLogs");

            migrationBuilder.DropTable(
                name: "NavigationLogs");

            migrationBuilder.DropTable(
                name: "NetworkLogs");
        }
    }
}
