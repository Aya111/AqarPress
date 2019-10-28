  using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(6)]
    public class _0006_CreateDeveloperTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Developer);
        }

        public override void Up()
        {
            Create.Table(Tables.Developer)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(500).NotNullable().Unique()
                .WithColumn("arabic_name").AsString(500).NotNullable()
                .WithColumn("path").AsString(100).NotNullable()
                .WithColumn("is_active").AsBoolean().WithDefaultValue(true);
        }
    }
}