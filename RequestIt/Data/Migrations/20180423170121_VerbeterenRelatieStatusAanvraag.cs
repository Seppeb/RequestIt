using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class VerbeterenRelatieStatusAanvraag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_AanvraagId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "AanvraagId",
                table: "Status");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Aanvragen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aanvragen_StatusId",
                table: "Aanvragen",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aanvragen_Status_StatusId",
                table: "Aanvragen",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aanvragen_Status_StatusId",
                table: "Aanvragen");

            migrationBuilder.DropIndex(
                name: "IX_Aanvragen_StatusId",
                table: "Aanvragen");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Aanvragen");

            migrationBuilder.AddColumn<int>(
                name: "AanvraagId",
                table: "Status",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_AanvraagId",
                table: "Status",
                column: "AanvraagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Aanvragen_AanvraagId",
                table: "Status",
                column: "AanvraagId",
                principalTable: "Aanvragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
