using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boilerplate.Migrations
{
    public partial class connection_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_AcceptingInviteId",
                table: "connections");

            migrationBuilder.DropForeignKey(
                name: "FK_connections_user_SendingInviteId",
                table: "connections");

            migrationBuilder.RenameColumn(
                name: "SendingInviteId",
                table: "connections",
                newName: "RightId");

            migrationBuilder.RenameColumn(
                name: "AcceptingInviteId",
                table: "connections",
                newName: "LeftId");

            migrationBuilder.RenameIndex(
                name: "IX_connections_SendingInviteId",
                table: "connections",
                newName: "IX_connections_RightId");

            migrationBuilder.RenameIndex(
                name: "IX_connections_AcceptingInviteId",
                table: "connections",
                newName: "IX_connections_LeftId");

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

            migrationBuilder.RenameColumn(
                name: "RightId",
                table: "connections",
                newName: "SendingInviteId");

            migrationBuilder.RenameColumn(
                name: "LeftId",
                table: "connections",
                newName: "AcceptingInviteId");

            migrationBuilder.RenameIndex(
                name: "IX_connections_RightId",
                table: "connections",
                newName: "IX_connections_SendingInviteId");

            migrationBuilder.RenameIndex(
                name: "IX_connections_LeftId",
                table: "connections",
                newName: "IX_connections_AcceptingInviteId");

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_AcceptingInviteId",
                table: "connections",
                column: "AcceptingInviteId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_connections_user_SendingInviteId",
                table: "connections",
                column: "SendingInviteId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
