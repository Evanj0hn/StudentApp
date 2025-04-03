using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramCode",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramCode",
                table: "Students",
                column: "ProgramCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_ProgramCode",
                table: "Students",
                column: "ProgramCode",
                principalTable: "Programs",
                principalColumn: "ProgramCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_ProgramCode",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProgramCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgramCode",
                table: "Students");
        }
    }
}
