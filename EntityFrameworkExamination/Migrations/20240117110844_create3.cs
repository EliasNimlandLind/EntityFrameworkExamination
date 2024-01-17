using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkExamination.Migrations
{
    /// <inheritdoc />
    public partial class create3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Posts",
                table: "Users",
                newName: "PostIds");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Blogs",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Posts",
                table: "Blogs",
                newName: "PostIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostIds",
                table: "Users",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Blogs",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "PostIds",
                table: "Blogs",
                newName: "Posts");
        }
    }
}
