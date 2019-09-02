using AqarPress.Core;
using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(3)]
    public class _0003_CreateCategoryTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Category);
        }

        public override void Up()
        {
            Create.Table(Tables.Category)
                  .WithColumn("id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("name").AsString(500).NotNullable()
                  .WithColumn("arabic_name").AsString(500).NotNullable();

            Insert.IntoTable(Tables.Category)
                .Row(new { name = ProjectCategories.Residential, arabic_name = "سكني" })
                .Row(new { name = ProjectCategories.Admin, arabic_name = "إداري" })
                .Row(new { name = ProjectCategories.Complex, arabic_name = "مبنى متعدد الأغراض" })
                .Row(new { name = ProjectCategories.Medical, arabic_name = "طبي" })
                .Row(new { name = ProjectCategories.Commercial, arabic_name = "تجاري" })
                .Row(new { name = ProjectCategories.OfficeAndRetail, arabic_name ="تجاري&إداري"})
                .Row(new { name = ProjectCategories.ResidentialAndCommercial, arabic_name = "سكنى& تجارى" });
        }
    }
}