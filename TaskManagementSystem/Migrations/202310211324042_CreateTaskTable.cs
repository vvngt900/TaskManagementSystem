namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTaskTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DeadlineDate = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        Task_TaskID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID)
                .Index(t => t.UserID)
                .Index(t => t.Task_TaskID);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Task_TaskID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Task_TaskID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Task_TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Comments", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.UserTasks", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.UserTasks", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserTasks", new[] { "Task_TaskID" });
            DropIndex("dbo.UserTasks", new[] { "User_UserID" });
            DropIndex("dbo.Comments", new[] { "Task_TaskID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "DepartmentID" });
            DropIndex("dbo.Tasks", new[] { "Department_DepartmentID" });
            DropTable("dbo.UserTasks");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Departments");
        }
    }
}
