using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class AlbumType:IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AlbumType()
        {
            this.ID = Guid.NewGuid();
        }
        public AlbumType(Genre bo)
        {
            this.ID = bo.ID;
            this.Name = bo.Name;
            this.Description = bo.Description;
        }
    }
}