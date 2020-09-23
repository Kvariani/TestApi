using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonDirectory.Infrastructure.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersonToPerson",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    RelatedPersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersonToPerson", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RelatedPersonToPerson_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedPersonToPerson_Persons_RelatedPersonID",
                        column: x => x.RelatedPersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelNumber",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    TelNumberType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelNumber", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TelNumber_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersonToPerson_PersonID",
                table: "RelatedPersonToPerson",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersonToPerson_RelatedPersonID",
                table: "RelatedPersonToPerson",
                column: "RelatedPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TelNumber_PersonID",
                table: "TelNumber",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedPersonToPerson");

            migrationBuilder.DropTable(
                name: "TelNumber");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
