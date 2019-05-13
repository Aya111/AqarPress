using AqarPress.Core;
using FluentMigrator;
using System.Web.Helpers;

namespace AqarPress.Migration
{
    [FluentMigrator.Migration(2)]
    public class _0002_CreateUserTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.User);
        }

        public override void Up()
        {
            Create.Table(Tables.User)
                  .WithColumn("id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("name").AsString(500).NotNullable()
                  .WithColumn("mobile_phone").AsString(50).NotNullable().Unique()
                  .WithColumn("password").AsString(500).NotNullable()
                  .WithColumn("role_id").AsInt32().ForeignKey(Tables.Role, "id").NotNullable()
                  .WithColumn("device_token").AsString(100).Nullable()
                  .WithColumn("date_created").AsDateTime().NotNullable().WithDefaultValue("GETUTCDATE()")
                  .WithColumn("last_login_date").AsDateTime().WithDefaultValue("GETUTCDATE()");

            Insert.IntoTable(Tables.User)
                .Row(new
                {
                    name = "Aya",
                    mobile_phone = "011233015100",
                    password = Crypto.HashPassword("1245"),
                    role_id = (int)UserRoles.Administrator
                });
        }
    }
}