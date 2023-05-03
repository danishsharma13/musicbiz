namespace F2022A6DS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trackmediatypeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "AudioContentType", c => c.String());
            AddColumn("dbo.Tracks", "Audio", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "Audio");
            DropColumn("dbo.Tracks", "AudioContentType");
        }
    }
}
