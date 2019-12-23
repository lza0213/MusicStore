using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Models.MusicStore;
using System.ComponentModel.DataAnnotations;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Models
{
    public class Student : IEntity
    {
        [Key]//主键
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Gender { get; set; }
        public string UserName { get; set; }//用户名
        public string NiName { get; set; }//昵称
        public DateTime Birthday { get; set; }//出生日期
        public int Age { get; set; }//年龄
        public string Password { get; set; }//密码
        public string ConfirmPassword { get; set; }//密码确认
        public string Email { get; set; }
        public decimal Contribution { get; set; }
        public DateTime CreatTime { get; set; }
        public DataStatus DataStatus { get; set; }
    }
        public enum DataStatus
        {
            合法用户,
            非法用户,
            冻结用户
        }
    
}