using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketWEB.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
			   name: "Provider",
			   columns: table => new
			   {
				   Id = table.Column<int>(type: "int", nullable: false)
					   .Annotation("SqlServer:Identity", "1, 1"),
				   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
				   Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
			   },
			   constraints: table =>
			   {
				   table.PrimaryKey("PK_Provider", x => x.Id);
			   });

		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			//DropTable("dbo.Provider");
			migrationBuilder.DropTable(
			   name: "Provider");
		}
    }
}
