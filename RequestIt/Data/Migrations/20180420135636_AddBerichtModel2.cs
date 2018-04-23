using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class AddBerichtModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bericht_Aanvragen_AanvraagId",
                table: "Bericht");

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
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bericht_Aanvragen_AanvraagId",
                table: "Bericht",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
