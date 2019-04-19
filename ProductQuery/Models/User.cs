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
        [Required(ErrorMessage = "*{0}是必填项")]
        public string name { get; set; }

        [Display(Name = "电话")]
        [Required(ErrorMessage = "*{0}是必填项")]
        [RegularExpression(@"^(13[0-9]|15[0-9]|18[0-9]|17[0-9])\d{8}$", ErrorMessage = "*不是手机号格式")]
        [MaxLength(11, ErrorMessage = "{0}最大长度{1}")]
        public string Phone { get; set; }

        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [DisplayName("确认密码")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "*密码和确认密码不匹配")]
        public string ConfirmPassword { get; set; }

        [DisplayName("权限")]
        public int permissions { get; set; }

    }
}