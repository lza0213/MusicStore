using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class Genre:IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre()
        {
            this.ID = Guid.NewGuid();
        }
        public Genre(Genre bo)
        {
            this.ID = bo.ID;
            this.Name = bo.Name;
            this.Description = bo.Description;
        }
    }
}