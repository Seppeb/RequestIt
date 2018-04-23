using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class AddBerichtModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bericht",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AanvraagId = table.Column<int>(nullable: true),
                    Inhoud = table.Column<string>(nullable: false),
                    Startdate = table.Column<DateTime>(nullable: false),
                    Titel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bericht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bericht_Aanvragen_AanvraagId",
                        column: x => x.AanvraagId,
                        principalTable: "Aanvragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bericht_AanvraagId",
                table: "Bericht",
                column: "AanvraagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bericht");
        }
    }
}
