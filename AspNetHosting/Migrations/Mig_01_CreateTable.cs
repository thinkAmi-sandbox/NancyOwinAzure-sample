using FluentMigrator;

namespace AspNetHosting.Migrations
{
    [Migration(2014111801)]
    public class Mig_01_CreateTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Ringo")
                .WithColumn("IDCol").AsInt32().PrimaryKey()
                .WithColumn("ContentCol").AsString().Nullable();

            Insert.IntoTable("Ringo")
                .Row(new { IDCol = 1, ContentCol = "つがる" })
                .Row(new { IDCol = 2, ContentCol = "秋映" })
                .Row(new { IDCol = 3, ContentCol = "シナノスイート" });
        }
    }
}