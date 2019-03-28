using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductQuery.Models
{
    public class ProductQueryDB:DbContext
    {
        //将实体对象写在这里，就可以生成对应的数据
        public DbSet<User> Users { get; set; }
        public DbSet<Ignition> Ignition { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<CableDiameter> CableDiameter { get; set; }
        public DbSet<Conventional> Conventional { get; set; }
        public DbSet<DcResistance> DcResistance { get; set; }
        public DbSet<DelayTime> DelayTime { get; set; }
        public DbSet<IgnitionCondition> IgnitionCondition { get; set; }
        public DbSet<InterfaceInformation> InterfaceInformation { get; set; }
        public DbSet<SpeedDetonation> SpeedDetonation { get; set; }
    }
}