using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boilerplate.Migrations
{
    public partial class bidder_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bidder_auctions_AuctionId",
                table: "Bidder");

            migrationBuilder.DropForeignKey(
                name: "FK_Bidder_user_Userid",
                table: "Bidder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bidder",
                table: "Bidder");

            migrationBuilder.RenameTable(
                name: "Bidder",
                newName: "bidders");

            migrationBuilder.RenameIndex(
                name: "IX_Bidder_Userid",
                table: "bidders",
                newName: "IX_bidders_Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Bidder_AuctionId",
                table: "bidders",
                newName: "IX_bidders_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bidders",
                table: "bidders",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_bidders_auctions_AuctionId",
                table: "bidders",
                column: "AuctionId",
                principalTable: "auctions",
                principalColumn: "AuctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bidders_user_Userid",
                table: "bidders",
                column: "Userid",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bidders_auctions_AuctionId",
                table: "bidders");

            migrationBuilder.DropForeignKey(
                name: "FK_bidders_user_Userid",
                table: "bidders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bidders",
                table: "bidders");

            migrationBuilder.RenameTable(
                name: "bidders",
                newName: "Bidder");

            migrationBuilder.RenameIndex(
                name: "IX_bidders_Userid",
                table: "Bidder",
                newName: "IX_Bidder_Userid");

            migrationBuilder.RenameIndex(
                name: "IX_bidders_AuctionId",
                table: "Bidder",
                newName: "IX_Bidder_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bidder",
                table: "Bidder",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bidder_auctions_AuctionId",
                table: "Bidder",
                column: "AuctionId",
                principalTable: "auctions",
                principalColumn: "AuctionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bidder_user_Userid",
                table: "Bidder",
                column: "Userid",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
