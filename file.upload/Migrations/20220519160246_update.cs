using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace file.upload.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "myFile",
                columns: table => new
                {
                    MyFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myFile", x => x.MyFileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myFile");
        }
    }
}
