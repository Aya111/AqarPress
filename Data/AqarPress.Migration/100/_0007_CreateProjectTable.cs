using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(7)]
    public class _0007_CreateProjectTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Project);
        }

        public override void Up()
        {
            Create.Table(Tables.Project)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(500).NotNullable().Unique()
                .WithColumn("arabic_name").AsString(500).NotNullable()
                .WithColumn("developer_id").AsInt32().ForeignKey(Tables.Developer, "id")
                .WithColumn("category_id").AsInt32().ForeignKey(Tables.Category, "id")
                .WithColumn("path").AsString(100).NotNullable()
                .WithColumn("date_created").AsDateTime().NotNullable().WithDefaultValue("GETUTCDATE()")
                .WithColumn("is_active").AsBoolean().NotNullable().WithDefaultValue(true);
        }
    }
}