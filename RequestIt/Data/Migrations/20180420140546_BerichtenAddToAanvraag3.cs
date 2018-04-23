using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class BerichtenAddToAanvraag3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten");

            migrationBuilder.AlterColumn<int>(
                name: "AanvraagId",
                table: "Berichten",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten");

            migrationBuilder.AlterColumn<int>(
                name: "AanvraagId",
                table: "Berichten",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Berichten_Aanvragen_AanvraagId",
                table: "Berichten",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
