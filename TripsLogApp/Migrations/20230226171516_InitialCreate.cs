using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripsLogApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    TripDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(nullable: false),
                    Accomodations = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstThingToDo = table.Column<string>(nullable: true),
                    SecondThingToDo = table.Column<string>(nullable: true),
                    ThirdThingToDo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.TripDetailID);
                });

            migrationBuilder.InsertData(
                table: "TripDetails",
                columns: new[] { "TripDetailID", "Accomodations", "Destination", "Email", "EndDate", "FirstThingToDo", "PhoneNumber", "SecondThingToDo", "StartDate", "ThirdThingToDo" },
                values: new object[] { 1, "the Galt House", "Louisville", "Trip1@gmail.com", new DateTime(2009, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go to the Derby", "502-555-9999", "Go drink bourbon", new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go eat Pizza" });

            migrationBuilder.InsertData(
                table: "TripDetails",
                columns: new[] { "TripDetailID", "Accomodations", "Destination", "Email", "EndDate", "FirstThingToDo", "PhoneNumber", "SecondThingToDo", "StartDate", "ThirdThingToDo" },
                values: new object[] { 2, "An AirBnB", "Gatlinburg", "Trip2@gmail.com", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go to Cade's Cove", "502-555-9999", "Go drink moonshine", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go eat pancakes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDetails");
        }
    }
}
