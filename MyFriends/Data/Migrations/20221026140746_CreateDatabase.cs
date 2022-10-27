using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFriends.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 25, "John" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 19, "Peter" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 3, 32, "Sam" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 4, 40, "Michael" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 5, 20, "Peppa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
