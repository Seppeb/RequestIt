using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RequestIt.Data.Migrations
{
    public partial class relatieUserAanvraag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Aanvragen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aanvragen_UserId",
                table: "Aanvragen",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aanvragen_AspNetUsers_UserId",
                table: "Aanvragen",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aanvragen_AspNetUsers_UserId",
                table: "Aanvragen");

            migrationBuilder.DropIndex(
                name: "IX_Aanvragen_UserId",
                table: "Aanvragen");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Aanvragen");
        }
    }
}
