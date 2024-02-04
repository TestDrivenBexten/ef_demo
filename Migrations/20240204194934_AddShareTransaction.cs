using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddShareTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShareTransaction",
                columns: table => new
                {
                    ShareTransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BalanceChange = table.Column<decimal>(type: "TEXT", nullable: false),
                    ShareId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareTransaction", x => x.ShareTransactionId);
                    table.ForeignKey(
                        name: "FK_ShareTransaction_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "ShareId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShareTransaction_ShareId",
                table: "ShareTransaction",
                column: "ShareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShareTransaction");
        }
    }
}
