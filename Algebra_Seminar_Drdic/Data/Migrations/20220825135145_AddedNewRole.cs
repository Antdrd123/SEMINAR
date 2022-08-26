using Algebra_Seminar_Drdic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Algebra_Seminar_Drdic.Data.Migrations
{
    public partial class AddedNewRole : Migration
    {
        const string USER_USER_GUID = "b2e8c18c-416c-4dbc-b17e-594a378f8990";
        const string USER_ROLE_GUID = "4b959098-0a85-44b0-a420-9207b86f7246";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();


            var passwordHash = hasher.HashPassword(null, "Lozinka12345");

            StringBuilder sb = new StringBuilder();

            // Kreiranje INSERT INTO querya
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName,LastName,Address)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{USER_USER_GUID}'");
            sb.AppendLine(",'User'");
            sb.AppendLine(",'USER@USER.COM'");
            sb.AppendLine(",'user@user.com'");
            sb.AppendLine(", +385917642062");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'USER@USER.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Maksimir'");
            sb.AppendLine(",'Drdic'");
            sb.AppendLine(",'Viteziceva 78'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{USER_ROLE_GUID}','User','USER')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{USER_USER_GUID}','{USER_ROLE_GUID}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{USER_USER_GUID}' AND RoleId = '{USER_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{USER_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{USER_ROLE_GUID}'");
        }
    }
}
