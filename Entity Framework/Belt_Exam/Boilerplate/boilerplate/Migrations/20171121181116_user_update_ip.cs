using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boilerplate.Migrations
{
    public partial class user_update_ip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_UserId",
                table: "connections");

            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_UserId1",
                table: "connections");

            migrationBuilder.DropIndex(
                name: "IX_connections_UserId",
                table: "connections");

            migrationBuilder.DropIndex(
                name: "IX_connections_UserId1",
                table: "connections");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "connections");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "connections");

            migrationBuilder.CreateIndex(
                name: "IX_connections_LeftId",
                table: "connections",
                column: "LeftId");

            migrationBuilder.CreateIndex(
                name: "IX_connections_RightId",
                table: "connections",
                column: "RightId");

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_LeftId",
                table: "connections",
                column: "LeftId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_RightId",
                table: "connections",
                column: "RightId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_LeftId",
                table: "connections");

            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_RightId",
                table: "connections");

            migrationBuilder.DropIndex(
                name: "IX_connections_LeftId",
                table: "connections");

            migrationBuilder.DropIndex(
                name: "IX_connections_RightId",
                table: "connections");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "connections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "connections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_connections_UserId",
                table: "connections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_connections_UserId1",
                table: "connections",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_UserId",
                table: "connections",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_UserId1",
                table: "connections",
                column: "UserId1",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
