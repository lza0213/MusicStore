
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Models.MusicStore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MVCMusicStore2019.ViewModels
{
    public class AlbumDisplayViewModel
    {
        public Guid ID { get; set; }//专辑编号
        public string OrderNumber { get; set; }

        public string Name { get; set; }//专辑名

        public string Description { get; set; }//简介

        public Guid GenreID { get; set; }//流派ID

        public string GenreName { get; set; }

        public Guid ArtistID { get; set; }//歌手ID

        public string ArtistName { get; set; }

        public Guid AlbumTypeID { get; set; }//类型ID

        public string AlbumTypeName { get; set; }

        public DateTime IssueDate { get; set; }//发型日期

        public string Issuer { get; set; }//发行人

        public string LanguageClassification { get; set; }//语种

        public decimal Price { get; set; }//价格

        public string Urlstring { get; set; }//图片传入路径及文件名
        public virtual Genre Genre { get; set; }//流派
        public virtual AlbumType AlbumType { get; set; }//类型
        public virtual Artist Artist { get; set; }//歌手
        public void MapToModel(Album model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
            this.Price = model.Price;
            this.Urlstring = model.Urlstring;
            this.Issuer = model.Issuer;
            this.LanguageClassification = model.LanguageClassification;

            if (model.Genre != null)
            {
                this.Genre.ID = model.Genre.ID;
                this.GenreName = model.Genre.Name;
            }
            if (model.AlbumType != null)
            {
                this.AlbumTypeID = model.AlbumType.ID;
                this.AlbumTypeName = model.AlbumType.Name;
            }
            if (model.Artist != null)
            {
                this.ArtistID = model.Artist.ID;
                this.ArtistName = model.Artist.Name;
            }
        }
    }



    public class AlbumViewModel
    {
        [Display(Name ="唱片ID")]
        [ScaffoldColumn(true)]//设定编辑表单时允许隐藏的字段

        public Guid ID { get; set; }//专辑编号

        [Display(Name="序号")]
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "专辑名是必填字段")]

        [Display(Name = "专辑名")]
        public string Name { get; set; }//专辑名

        [Display(Name = "简介")]
        [Required(ErrorMessage ="简介字段不能为空")]
        public string Description { get; set; }//简介

        [Display(Name = "流派ID")]
        public Guid GenreID { get; set; }//流派ID

        [Display(Name="流派名称")]
        public string GenreName { get; set; }

        [Display(Name = "歌手ID")]
        public Guid ArtistID { get; set; }//歌手ID

        [Display(Name = "歌手名称")]
        public string ArtistName { get; set; }

        [Display(Name = "专辑类型ID")]
        public Guid AlbumTypeID { get; set; }//类型ID

        [Display(Name = "专辑类型名称")]
        public string AlbumTypeName { get; set; }

        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确的日期")]
      
        public DateTime IssueDate { get; set; }//发型日期

        [Display(Name = "发行人")]
        [Required(ErrorMessage = "发行人是必填字段")]
        public string Issuer { get; set; }//发行人

        [Display(Name = "语种")]
        public string LanguageClassification { get; set; }//语种

        [Display(Name="价格")]
        [Required(ErrorMessage = "价格是必填字段")]
        [Range(typeof(decimal), "0.00", "100.00", ErrorMessage = "价格为￥0.00-￥100.00之间")]
        public decimal Price { get; set; }//价格

        [Display(Name="封面链接")]
        public string Urlstring { get; set; }//图片传入路径及文件名
        public virtual Genre Genre { get; set; }//流派
        public virtual AlbumType AlbumType { get; set; }//类型

        [Display(Name = "歌手")]
        public virtual Artist Artist { get; set; }//歌手
        public AlbumViewModel(Album model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            if (model.Genre != null)
            {
                this.GenreID = model.Genre.ID;
                this.GenreName = model.Genre.Name;
            }
            if (model.Artist != null)
            {
                this.ArtistID = model.Artist.ID;
                this.ArtistName = model.Artist.Name;
            }
            if (model.AlbumType != null)
            {
                this.AlbumTypeID = model.AlbumType.ID;
                this.AlbumTypeName = model.AlbumType.Name;
            }
            this.Description = model.Description;
            this.IssueDate = model.IssueDate;
            this.Issuer = model.Issuer;
            this.LanguageClassification = model.LanguageClassification;
            this.Price = model.Price;
            this.Urlstring = model.Urlstring;

        }

        public AlbumViewModel()
        {
        }

        //public void MapToModel (AlbumViewModel model)
        //{
        //    ID = model.ID;
        //    Name = model.Name;
        //    Description = model.Description;
        //    Price = model.Price;
        //    Issuer = model.Issuer;
        //    IssueDate = model.IssueDate;
        //    LanguageClassification = model.LanguageClassification;
        //    Urlstring = model.Urlstring;
        //    AlbumType = model.AlbumType;
        //    Genre = model.Genre;
        //    Artist = model.Artist;
        //}
        public void MapToModel(Album model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
            this.Price = model.Price;
            this.Urlstring = model.Urlstring;
            this.Issuer = model.Issuer;
            this.IssueDate = model.IssueDate;
            this.LanguageClassification = model.LanguageClassification;
            if (model.Genre != null)
            {
                this.GenreID = model.Genre.ID;
                this.GenreName = model.Genre.Name;
            }
            if (model.AlbumType != null)
            {
                this.AlbumTypeID = model.AlbumType.ID;
                this.AlbumTypeName = model.AlbumType.Name;
            }
            if (model.Artist != null)
            {
                this.ArtistID = model.Artist.ID;
                this.ArtistName = model.Artist.Name;
            }
        }

    }
}