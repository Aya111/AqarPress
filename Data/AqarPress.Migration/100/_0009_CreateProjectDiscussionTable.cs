using FluentMigrator;

namespace AqarPress.Migration
{
    [Migration(9)]
    public class _0009_CreateProjectDiscussionTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.ProjectDiscussion);
        }

        public override void Up()
        {
            Create.Table(Tables.ProjectDiscussion)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("message_body").AsString(500).NotNullable()
                .WithColumn("commenter_id").AsInt32().ForeignKey(Tables.User, "id").NotNullable()
                .WithColumn("project_id").AsInt32().ForeignKey(Tables.Project, "id").NotNullable()
                .WithColumn("date_created").AsDateTime().NotNullable().WithDefaultValue("GETUTCDATE()");
        }
    }
}