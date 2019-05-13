using AqarPress.Migration;
using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(5)]
    public class _0005_CreateAreaTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Area);
        }

        public override void Up()
        {
            Create.Table(Tables.Area)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(500).NotNullable().Unique()
                .WithColumn("arabic_name").AsString(500).NotNullable().Unique();
        }
    }
}