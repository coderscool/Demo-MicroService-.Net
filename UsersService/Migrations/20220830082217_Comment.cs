using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersService.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Count", "PostId", "Status" },
                values: new object[] { 1, 0, 1, "SOFM" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Count", "PostId", "Status" },
                values: new object[] { 2, 0, 2, "SN" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Count", "PostId", "Status" },
                values: new object[] { 3, 0, 3, "WBG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
