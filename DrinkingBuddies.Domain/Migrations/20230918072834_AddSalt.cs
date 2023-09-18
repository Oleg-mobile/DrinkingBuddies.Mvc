﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkingBuddies.Domain.Migrations
{
    public partial class AddSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Members");
        }
    }
}
