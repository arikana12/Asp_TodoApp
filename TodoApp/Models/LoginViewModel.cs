using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }
        [DisplayName("パスワード")]
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}