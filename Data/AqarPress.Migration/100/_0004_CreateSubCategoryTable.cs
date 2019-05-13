using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(4)]
    public class _0004_CreateSubCategoryTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.SubCategory);
        }

        public override void Up()
        {
            Create.Table(Tables.SubCategory)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(500).NotNullable()
                .WithColumn("arabic_name").AsString(500).NotNullable();
        }
    }
}