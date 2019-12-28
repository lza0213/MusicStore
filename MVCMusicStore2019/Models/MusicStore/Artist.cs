using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStore
{
    public class Artist:IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Artist()
        {
            this.ID = Guid.NewGuid();
        }
        public Artist(Artist artist)
        {
            this.ID = artist.ID;
            this.Name = artist.Name;
            this.Description = artist.Description;
        }
    }
}