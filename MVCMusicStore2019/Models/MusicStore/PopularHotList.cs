using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class PopularHotList:IEntity
    {
        public Guid ID { get; set; }
        public Guid AlbumID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CTR { get; set; }
        public Album Album { get; set; }//音乐专辑关联类
        public PopularHotList()
        {
            this.ID = Guid.NewGuid();
            CTR = 0;
            this.Name = DateTime.Now.ToShortDateString();//上榜日期
            this.Description = this.Name + "上榜";
        }
        public PopularHotList(AlbumViewModel vm)
        {
            this.ID = vm.ID;
            this.Name = "热榜名单";
            this.Description = this.Name;
        }
    }
}