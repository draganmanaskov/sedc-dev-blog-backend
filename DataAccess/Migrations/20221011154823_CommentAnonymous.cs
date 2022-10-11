using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlog.DataAccess.Migrations
{
    public partial class CommentAnonymous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anonymous",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anonymous",
                table: "Comments");
        }
    }
}
