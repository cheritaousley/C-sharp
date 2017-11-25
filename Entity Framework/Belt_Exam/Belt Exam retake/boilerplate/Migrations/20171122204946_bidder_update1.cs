using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boilerplate.Migrations
{
    public partial class bidder_update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bidders_user_Userid",
                table: "bidders");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "bidders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bidders_Userid",
                table: "bidders",
                newName: "IX_bidders_UserId");

            migrationBuilder.AddColumn<int>(
                name: "bidAmount",
                table: "bidders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_bidders_user_UserId",
                table: "bidders",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bidders_user_UserId",
                table: "bidders");

            migrationBuilder.DropColumn(
                name: "bidAmount",
                table: "bidders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bidders",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_bidders_UserId",
                table: "bidders",
                newName: "IX_bidders_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_bidders_user_Userid",
                table: "bidders",
                column: "Userid",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
