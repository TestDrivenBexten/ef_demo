using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class RenameShareTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShareTransaction_Shares_ShareId",
                table: "ShareTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShareTransaction",
                table: "ShareTransaction");

            migrationBuilder.RenameTable(
                name: "ShareTransaction",
                newName: "ShareTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_ShareTransaction_ShareId",
                table: "ShareTransactions",
                newName: "IX_ShareTransactions_ShareId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShareTransactions",
                table: "ShareTransactions",
                column: "ShareTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShareTransactions_Shares_ShareId",
                table: "ShareTransactions",
                column: "ShareId",
                principalTable: "Shares",
                principalColumn: "ShareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShareTransactions_Shares_ShareId",
                table: "ShareTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShareTransactions",
                table: "ShareTransactions");

            migrationBuilder.RenameTable(
                name: "ShareTransactions",
                newName: "ShareTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_ShareTransactions_ShareId",
                table: "ShareTransaction",
                newName: "IX_ShareTransaction_ShareId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShareTransaction",
                table: "ShareTransaction",
                column: "ShareTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShareTransaction_Shares_ShareId",
                table: "ShareTransaction",
                column: "ShareId",
                principalTable: "Shares",
                principalColumn: "ShareId");
        }
    }
}
