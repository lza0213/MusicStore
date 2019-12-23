using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class Album : IEntity
    {
        public Guid ID { get; set; }//专辑编号
        public string Name { get; set; }//专辑名
        public string Description { get; set; }//简介
        public Guid GenreID { get; set; }//流派ID
        public Guid ArtistID { get; set; }//歌手ID
        public  Guid AlbumTypeID{get;set ;}//类型ID
        public DateTime IssueDate { get; set; }//发型日期
        public string Issuer { get; set; }//发行人
        public string LanguageClassification { get; set; }//语种
        public string Urlstring { get; set; }//图片传入路径及文件名
        public decimal Price { get; set; }//价格
        public virtual Genre Genre { get; set; }//流派
        public virtual AlbumType AlbumType { get; set; }//类型
        public virtual Artist Artist { get; set; }//歌手

        public Album()
        {
            this.ID= Guid.NewGuid();
            this.IssueDate = DateTime.Now;
            this.Price = 0.00M;
        }
        public Album(Album bo)
        {
            this.ID = bo.ID;
            this.Name = bo.Name;
            this.Description = bo.Description;
            this.IssueDate = bo.IssueDate;
            this.Issuer = bo.Issuer;
            this.LanguageClassification = bo.LanguageClassification;
            this.Price = bo.Price;
            if (Genre != null)
            {
                this.GenreID = bo.Genre.ID;
                this.Genre.ID = bo.Genre.ID;
                this.Genre.Name = bo.Genre.Name;
                this.Genre.Description = bo.Genre.Description;
            }
            if(AlbumType!=null)
            {
                this.AlbumTypeID = bo.AlbumType.ID;
                this.AlbumType.ID = bo.AlbumType.ID;
                this.AlbumType.Name = bo.AlbumType.Name;
                this.AlbumType.Description = bo.AlbumType.Description;
            }
            if(Artist != null)
            {

                this.ArtistID = bo.Artist.ID;
                this.Artist.ID= bo.Artist.ID;
                this.Artist.Name = bo.Artist.Name;
                this.Artist.Description = bo.Artist.Description;
            }

        }
        public void MapToModel(AlbumViewModel model)
        {
            this.ID= model.ID;
            this.Name = model.Name;
            this.Description = model.Description;
            this.Price = model.Price;
            this.Urlstring = model.Urlstring;
            this.Issuer = model.Issuer;
            this.LanguageClassification = model.LanguageClassification;

            if (model.Genre != null)
            {
                this.GenreID = model.GenreID;
                this.Genre.Name = model.GenreName;
            }
            if (model.AlbumType != null)
            {
                this.AlbumTypeID = model.AlbumTypeID;
                this.AlbumType.Name = model.AlbumTypeName;
            }
            if (model.Artist != null)
            {
                this.ArtistID = model.ArtistID;
                this.Artist.Name = model.ArtistName;
            }
        }
    }
}