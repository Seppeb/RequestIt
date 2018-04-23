using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class AanvraagrelatieOptioneel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "AanvraagId",
                table: "Status",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "AanvraagId",
                table: "Status",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
