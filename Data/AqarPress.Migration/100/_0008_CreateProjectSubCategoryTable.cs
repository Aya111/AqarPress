using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(8)]
    public class _0008_CreateProjectSubCategoryTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.ProjectSubCatogoryTable);
        }

        public override void Up()
        {
            Create.Table(Tables.ProjectSubCatogoryTable)
               .WithColumn("id").AsInt32().PrimaryKey().Identity()
               .WithColumn("project_id").AsInt32().ForeignKey(Tables.Project, "id")
               .WithColumn("sub_category_id").AsInt32().ForeignKey(Tables.SubCategory, "id");
        }
    }
}