using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarmonyInTheHome.Data.Migrations
{
    public partial class firstEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapUrl",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapUrl",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Restaurants");
        }
    }
}
