using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactApi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grocery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Caloreis = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grocery", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Grocery",
                columns: new[] { "Id", "Caloreis", "Cost", "Name", "Weight" },
                values: new object[] { 1, 144m, 89m, "Grocery 1", 66m });

            migrationBuilder.InsertData(
                table: "Grocery",
                columns: new[] { "Id", "Caloreis", "Cost", "Name", "Weight" },
                values: new object[] { 2, 1244m, 849m, "Grocery 2", 776m });

            migrationBuilder.InsertData(
                table: "Grocery",
                columns: new[] { "Id", "Caloreis", "Cost", "Name", "Weight" },
                values: new object[] { 3, 164m, 84m, "Grocery 3", 56m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grocery");
        }
    }
}
