using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "IdLanguage", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "IdStudent", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "tomcio@wp.pl", "Tomek", "Kowalski" },
                    { 2, "aniaK@wp.pl", "Ala", "Kowalska" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "IdTask", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Write a program that prints the numbers from 1 to 100.", "Fizz-Buzz" },
                    { 2, "Check if a string is a palindrome.", "Palindrome" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "IdRecord", "CreatedAt", "ExecutionTime", "IdLanguage", "IdStudent", "IdTask" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 5, 29, 5, 50, 6, 0, DateTimeKind.Unspecified), 1233, 1, 1, 1 },
                    { 2, new DateTime(2016, 4, 10, 10, 20, 0, 0, DateTimeKind.Unspecified), 874, 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "IdRecord",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "IdRecord",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "IdLanguage",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "IdLanguage",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "IdStudent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "IdStudent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "IdTask",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "IdTask",
                keyValue: 2);
        }
    }
}
