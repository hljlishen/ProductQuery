namespace ProductQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CableDiameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        普通索直径 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.Ignitions",
                c => new
                    {
                        IgnitionId = c.Int(nullable: false, identity: true),
                        类别 = c.String(),
                        产品名称 = c.String(),
                        设计单位 = c.String(),
                        型号 = c.String(),
                        图号 = c.String(),
                        代号 = c.String(),
                        研制日期 = c.DateTime(nullable: false),
                        定型日期 = c.DateTime(nullable: false),
                        用途 = c.String(),
                        系统组成 = c.String(),
                        目前阶段 = c.String(),
                        机械性能 = c.String(),
                        电性能 = c.String(),
                        功能 = c.String(),
                        环境测试 = c.String(),
                        桥丝数目 = c.Int(nullable: false),
                        贮存寿命 = c.Int(nullable: false),
                        贮存寿命备注 = c.String(),
                        可靠度 = c.String(),
                        主要性能指标 = c.String(),
                        试验环境指标范围 = c.String(),
                        基本性能 = c.String(),
                        脚线 = c.Double(nullable: false),
                        总长度 = c.Double(nullable: false),
                        隔板厚度 = c.Double(nullable: false),
                        索直径上限 = c.Double(nullable: false),
                        索直径下限 = c.Double(nullable: false),
                        索MDF银质直径 = c.Double(nullable: false),
                        对边 = c.Int(nullable: false),
                        对角线 = c.Double(nullable: false),
                        检测电流 = c.Double(nullable: false),
                        静电电容 = c.Double(nullable: false),
                        静电电压 = c.Double(nullable: false),
                        串联电阻 = c.Double(nullable: false),
                        静电感度备注 = c.String(),
                        作用时间 = c.Double(nullable: false),
                        作用时间单位 = c.String(),
                        作用时间下限 = c.Double(nullable: false),
                        作用时间上限 = c.Double(nullable: false),
                        作用时间备注 = c.String(),
                        桥个数 = c.Double(nullable: false),
                        安全电流值 = c.Double(nullable: false),
                        安全电流值下限 = c.Double(nullable: false),
                        安全电流值上限 = c.Double(nullable: false),
                        安全电流值单位 = c.String(),
                        时间值 = c.Double(nullable: false),
                        时间单位 = c.String(),
                        功率值 = c.Double(nullable: false),
                        安全电流备注 = c.String(),
                        安全电压电压 = c.Double(nullable: false),
                        安全电压电容 = c.Double(nullable: false),
                        燃烧压力下限 = c.Double(nullable: false),
                        燃烧压力上限 = c.Double(nullable: false),
                        燃烧压力备注 = c.String(),
                    })
                .PrimaryKey(t => t.IgnitionId);
            
            CreateTable(
                "dbo.Conventionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        尺寸名称 = c.String(),
                        直径 = c.Double(nullable: false),
                        长度 = c.Double(nullable: false),
                        高度 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.IgnitionConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        桥个数 = c.Int(nullable: false),
                        发火电压 = c.Double(nullable: false),
                        发火电压下限 = c.Double(nullable: false),
                        发火电压上限 = c.Double(nullable: false),
                        发火电容 = c.Double(nullable: false),
                        发火电容单位 = c.String(),
                        发火电流 = c.Double(nullable: false),
                        发火电流下限 = c.Double(nullable: false),
                        发火电流上限 = c.Double(nullable: false),
                        发火电流单位 = c.String(),
                        发火电流时间 = c.Double(nullable: false),
                        发火电流时间单位 = c.String(),
                        锤重 = c.Double(nullable: false),
                        锤重单位 = c.String(),
                        落高 = c.Double(nullable: false),
                        落高单位 = c.String(),
                        击针刺激量 = c.Double(nullable: false),
                        击针力下限 = c.Double(nullable: false),
                        击针力上限 = c.Double(nullable: false),
                        击针突出量下限 = c.Double(nullable: false),
                        击针突出量上限 = c.Double(nullable: false),
                        弹簧高度 = c.Double(nullable: false),
                        抗力 = c.Double(nullable: false),
                        能量 = c.Double(nullable: false),
                        能量单位 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.InterfaceInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        螺纹 = c.Double(nullable: false),
                        螺距 = c.Double(nullable: false),
                        公差 = c.String(),
                        长度 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.SpeedDetonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        爆速上限 = c.Double(nullable: false),
                        爆速下限 = c.Double(nullable: false),
                        爆速备注 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.DelayTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        温度条件 = c.Double(nullable: false),
                        延期时间下限 = c.Double(nullable: false),
                        延期时间上限 = c.Double(nullable: false),
                        延期时间单位 = c.String(),
                        延期时间值 = c.Double(nullable: false),
                        延期时间值误差 = c.Double(nullable: false),
                        延期时间值误差上限 = c.Double(nullable: false),
                        延期时间值误差下限 = c.Double(nullable: false),
                        延期时间备注 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.DcResistances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IgnitionID = c.Int(nullable: false),
                        电阻桥个数 = c.Int(nullable: false),
                        电阻单位 = c.String(),
                        电阻范围值上 = c.Double(nullable: false),
                        电阻范围值下 = c.Double(nullable: false),
                        电阻值 = c.Double(nullable: false),
                        电阻公差值 = c.Double(nullable: false),
                        电阻小于值 = c.Double(nullable: false),
                        电阻备注 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ignitions", t => t.IgnitionID, cascadeDelete: true)
                .Index(t => t.IgnitionID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        password = c.String(),
                        permissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DcResistances", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.DelayTimes", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.Pictures", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.SpeedDetonations", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.CableDiameters", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.InterfaceInformations", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.IgnitionConditions", "IgnitionID", "dbo.Ignitions");
            DropForeignKey("dbo.Conventionals", "IgnitionID", "dbo.Ignitions");
            DropIndex("dbo.DcResistances", new[] { "IgnitionID" });
            DropIndex("dbo.DelayTimes", new[] { "IgnitionID" });
            DropIndex("dbo.Pictures", new[] { "IgnitionID" });
            DropIndex("dbo.SpeedDetonations", new[] { "IgnitionID" });
            DropIndex("dbo.InterfaceInformations", new[] { "IgnitionID" });
            DropIndex("dbo.IgnitionConditions", new[] { "IgnitionID" });
            DropIndex("dbo.Conventionals", new[] { "IgnitionID" });
            DropIndex("dbo.CableDiameters", new[] { "IgnitionID" });
            DropTable("dbo.Users");
            DropTable("dbo.DcResistances");
            DropTable("dbo.DelayTimes");
            DropTable("dbo.Pictures");
            DropTable("dbo.SpeedDetonations");
            DropTable("dbo.InterfaceInformations");
            DropTable("dbo.IgnitionConditions");
            DropTable("dbo.Conventionals");
            DropTable("dbo.Ignitions");
            DropTable("dbo.CableDiameters");
        }
    }
}
