using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductQuery.Models
{
    public class User
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("name")]
        public string name { get; set; }
        [DisplayName("password")]
        public string password { get; set; }
        [DisplayName("permissions")]
        public int permissions { get; set; }
    }
}