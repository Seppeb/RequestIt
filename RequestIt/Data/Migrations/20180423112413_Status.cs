using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Berichten",
                table: "Berichten");

            migrationBuilder.RenameTable(
                name: "Berichten",
                newName: "Bericht");

            migrationBuilder.RenameIndex(
                name: "IX_Berichten_AanvraagId",
                table: "Bericht",
                newName: "IX_Bericht_AanvraagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bericht",
                table: "Bericht",
                column: "BerichtId");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AanvraagId = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Aanvragen_AanvraagId",
                        column: x => x.AanvraagId,
                        principalTable: "Aanvragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_AanvraagId",
                table: "Status",
                column: "AanvraagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bericht_Aanvragen_AanvraagId",
                table: "Bericht",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bericht_Aanvragen_AanvraagId",
                table: "Bericht");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bericht",
                table: "Bericht");

            migrationBuilder.RenameTable(
                name: "Bericht",
                newName: "Berichten");

            migrationBuilder.RenameIndex(
                name: "IX_Bericht_AanvraagId",
                table: "Berichten",
                newName: "IX_Berichten_AanvraagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Berichten",
                table: "Berichten",
                column: "BerichtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
