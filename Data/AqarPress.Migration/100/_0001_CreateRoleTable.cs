using AqarPress.Core;
using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(1)]
    public class _0001_CreateRoleTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Role);
        }

        public override void Up()
        {
            Create.Table(Tables.Role)
                  .WithColumn("id").AsInt32().PrimaryKey()
                  .WithColumn("name").AsString(500).NotNullable();

            Insert.IntoTable(Tables.Role)
                .Row(new { id = (int)UserRoles.Administrator, name = UserRoles.Administrator })
                .Row(new { id = (int)UserRoles.Broker, name = UserRoles.Broker })
                .Row(new { id = (int)UserRoles.Normal, name = UserRoles.Normal });
        }
    }
}