namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckModelChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserTasks", newName: "TaskUsers");
            DropPrimaryKey("dbo.TaskUsers");
            AddPrimaryKey("dbo.TaskUsers", new[] { "Task_TaskID", "User_UserID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TaskUsers");
            AddPrimaryKey("dbo.TaskUsers", new[] { "User_UserID", "Task_TaskID" });
            RenameTable(name: "dbo.TaskUsers", newName: "UserTasks");
        }
    }
}
