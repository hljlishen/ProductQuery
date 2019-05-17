using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductQuery.Models
{
    public class User
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("用户名")]
        public string name { get; set; }

        [Display(Name = "电话")]
        public string Phone { get; set; }

        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [DisplayName("确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("权限")]
        public string permissions { get; set; }

    }
}