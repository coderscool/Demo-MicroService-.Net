using Microsoft.EntityFrameworkCore.Migrations;

namespace PostsService.Migrations
{
    public partial class PostService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Letter = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Count", "Image", "Letter", "Title" },
                values: new object[] { 1, 1, "cde", "Trận chung kết", "Champion League" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Count", "Image", "Letter", "Title" },
                values: new object[] { 2, 1, "ghi", "Ta sẽ trở thành vua hải tặc", "Laugh Tale" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Count", "Image", "Letter", "Title" },
                values: new object[] { 3, 1, "gkl", "Dự án trang trại", "Team châu phi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
