using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "اجهزة الكترونية"},
                    { 2, "اكسسوارات"},
                    { 3, "ملابس", }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
