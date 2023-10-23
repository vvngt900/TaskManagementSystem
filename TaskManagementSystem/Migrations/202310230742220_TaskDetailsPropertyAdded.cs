namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskDetailsPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Details");
        }
    }
}
