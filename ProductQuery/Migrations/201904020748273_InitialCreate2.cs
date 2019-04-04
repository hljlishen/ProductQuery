namespace ProductQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ignitions", "研制日期", c => c.DateTime());
            AlterColumn("dbo.Ignitions", "定型日期", c => c.DateTime());
            AlterColumn("dbo.Ignitions", "工艺定型", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ignitions", "工艺定型", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ignitions", "定型日期", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ignitions", "研制日期", c => c.DateTime(nullable: false));
        }
    }
}
