using Microsoft.EntityFrameworkCore.Migrations;

namespace todo.Migrations
{
    public partial class AddDoneDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(name: "Done", table: "Todos", defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(name: "Done", table: "Todos", defaultValue: null);
        }
    }
}
