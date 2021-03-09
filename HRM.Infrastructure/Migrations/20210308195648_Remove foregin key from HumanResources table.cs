using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Infrastructure.Migrations
{
    public partial class RemoveforeginkeyfromHumanResourcestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanResources_Departments_DepartmentId1",
                table: "HumanResources");

            migrationBuilder.DropIndex(
                name: "IX_HumanResources_DepartmentId1",
                table: "HumanResources");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "HumanResources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId1",
                table: "HumanResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HumanResources_DepartmentId1",
                table: "HumanResources",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HumanResources_Departments_DepartmentId1",
                table: "HumanResources",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
