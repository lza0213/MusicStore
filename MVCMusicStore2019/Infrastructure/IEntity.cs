using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Infrastructure
{
    public interface IEntity
    {
        Guid ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
