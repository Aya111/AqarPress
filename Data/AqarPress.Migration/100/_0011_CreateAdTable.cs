using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarPress.Migration._100
{

    [Migration(11)]
    public class _0011_CreateAdTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table(Tables.Ad);
        }

        public override void Up()
        {
            Create.Table(Tables.Ad)
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString(500).NotNullable()
                .WithColumn("redirect_url").AsString(500).NotNullable()
                .WithColumn("path").AsString(100).NotNullable()
                .WithColumn("is_active").AsBoolean().WithDefaultValue(true); ;
        }
    }
}
