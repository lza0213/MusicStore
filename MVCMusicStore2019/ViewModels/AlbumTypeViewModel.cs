using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Models.MusicStore;

namespace MVCMusicStore2019.ViewModels
{
    public class AlbumTypeDisplayViewModel
    {
        [Display(Name = "专辑类型ID")]
        public Guid ID { get; set; }
        [Display(Name = "专辑类型名称")]
        public string Name { get; set; }
        [Display(Name = "简介")]
        public string Description { get; set; }
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
    }


    public class AlbumTypeViewModel
    {
        [Display(Name = "专辑类型ID")]
        [ScaffoldColumn(true)]
        public Guid ID { get; set; }
        [Display(Name ="专辑类型名称")]
        [Required(ErrorMessage = "专辑类型是必填字段")]
        public string Name { get; set; }
        [Display(Name ="简介")]
        [Required(ErrorMessage ="简介是必填字段")]
        public string Description { get; set; }
        public string OrderNumber { get; set; }
        public AlbumTypeViewModel() { }

        public AlbumTypeViewModel(AlbumType model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(AlbumType model)
        {
            model.ID = ID;
            model.Name = Name;
            model.Description = Description;
        }
    }
}