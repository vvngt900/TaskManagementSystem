namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusPropertyAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        TaskStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TaskStatusID);
            
            AddColumn("dbo.Tasks", "Status_TaskStatusID", c => c.Int());
            CreateIndex("dbo.Tasks", "Status_TaskStatusID");
            AddForeignKey("dbo.Tasks", "Status_TaskStatusID", "dbo.TaskStatus", "TaskStatusID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Status_TaskStatusID", "dbo.TaskStatus");
            DropIndex("dbo.Tasks", new[] { "Status_TaskStatusID" });
            DropColumn("dbo.Tasks", "Status_TaskStatusID");
            DropTable("dbo.TaskStatus");
        }
    }
}
