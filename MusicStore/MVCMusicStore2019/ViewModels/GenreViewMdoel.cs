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
    public class GenreDisplayViewModel
    {
        [Display(Name = "流派ID")]
        public Guid ID { get; set; }
        [Display(Name = "流派名称")]
        public string Name { get; set; }
        [Display(Name = "流派简介")]
        public string Description { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
    }


    public class GenreViewMdoel
    {
        [Display(Name = "流派ID")]
        [ScaffoldColumn(true)]
        public Guid ID { get; set; }
        [Display(Name = "流派名称")]
        [Required(ErrorMessage = "流派名称是必填字段")]
        public string Name { get; set; }
        [Display(Name = "流派简介")]
        [Required(ErrorMessage ="流派简介是必填字段")]
        public string Description { get; set; }
        public string OrderNumber { get; set; }

        public GenreViewMdoel(Genre model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Genre model)
        {
            model.ID = ID;
            model.Name = Name;
            model.Description = Description;
        }
        public GenreViewMdoel() { }
    }
}