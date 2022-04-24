using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerAdmin.Admin.EntityFramework.SqlServer.Migrations.IdentityServerConfiguration
{
    /// <inheritdoc />
    public partial class NewUpdateCleanUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients");
        }
    }
}
