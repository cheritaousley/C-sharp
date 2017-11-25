using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace boilerplate.Migrations
{
    public partial class bidder_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bidAmount",
                table: "bidders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bidAmount",
                table: "bidders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
