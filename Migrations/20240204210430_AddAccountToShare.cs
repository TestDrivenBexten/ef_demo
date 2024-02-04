using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountToShare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Accounts_AccountId",
                table: "Shares");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Shares",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Accounts_AccountId",
                table: "Shares",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Accounts_AccountId",
                table: "Shares");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Shares",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Accounts_AccountId",
                table: "Shares",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
