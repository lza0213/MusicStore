using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCMusicStore2019.Models.MusicStore;

namespace MVCMusicStore2019.ViewModels
{
    public class ArtistDisplayViewModel
    {
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
        [Display(Name = "流派ID")]
        public Guid ID { get; set; }
        [Display(Name = "艺术家")]
        public string Name { get; set; }
        [Display(Name = "简介")]
        public string Description { get; set; }
    }



    public class ArtistViewModel
    {
        [Display(Name = "流派ID")]
        [ScaffoldColumn(true)]

        public string OrderNumber { get; set; }
        public Guid ID { get; set; }
        [Display(Name="艺术家")]
        [Required(ErrorMessage ="艺术家名称是必填字段")]
        public string Name { get; set; }
        [Display(Name ="简介")]
        [Required(ErrorMessage ="艺术家简介是必填字段")]
        public string Description { get; set; }

        public ArtistViewModel(Artist model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Artist model)
        {
            model.ID = ID;
            model.Name = Name;
            model.Description = Description;
        }
        public ArtistViewModel() { }
    }
}