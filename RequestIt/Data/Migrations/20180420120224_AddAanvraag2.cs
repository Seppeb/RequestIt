using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class AddAanvraag2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aanvragen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EindDatum = table.Column<DateTime>(nullable: false),
                    LinkVoorbeeldBehandelaar = table.Column<string>(nullable: true),
                    LinkVoorbeeldKlant = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: false),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    Titel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvragen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvragen");
        }
    }
}
