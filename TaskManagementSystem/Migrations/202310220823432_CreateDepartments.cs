namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Name) VALUES ('Development')");
            Sql("INSERT INTO Departments (Name) VALUES ('QA')");
            Sql("INSERT INTO Departments (Name) VALUES ('Design')");
            Sql("INSERT INTO Departments (Name) VALUES ('Management')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Departments");
        }
    }
}
