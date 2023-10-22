namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableManyToManyTaskUserRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TaskUsers", newName: "TaskUser");
            RenameColumn(table: "dbo.TaskUser", name: "Task_TaskID", newName: "TaskID");
            RenameColumn(table: "dbo.TaskUser", name: "User_UserID", newName: "UserID");
            RenameIndex(table: "dbo.TaskUser", name: "IX_Task_TaskID", newName: "IX_TaskID");
            RenameIndex(table: "dbo.TaskUser", name: "IX_User_UserID", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TaskUser", name: "IX_UserID", newName: "IX_User_UserID");
            RenameIndex(table: "dbo.TaskUser", name: "IX_TaskID", newName: "IX_Task_TaskID");
            RenameColumn(table: "dbo.TaskUser", name: "UserID", newName: "User_UserID");
            RenameColumn(table: "dbo.TaskUser", name: "TaskID", newName: "Task_TaskID");
            RenameTable(name: "dbo.TaskUser", newName: "TaskUsers");
        }
    }
}
