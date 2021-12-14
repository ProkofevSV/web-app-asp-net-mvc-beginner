namespace TodoListFoTheDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.TodoLists",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Weekday = c.String(nullable: false),
                   Time = c.DateTime(nullable: false),
                   Hard = c.String(nullable: false),
                   Flex = c.String(nullable: false),
                   CreateAt = c.DateTime(nullable: false),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoLists");
        }
    }
}
