using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MVCMusicStore2019Test
{
    public class ArtistTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Artist _artist;
        public ArtistTest(ITestOutputHelper output)

        {
            _output = output;
            _artist = new Artist();
        }
        [Fact]
        public void ArtisEntityTest()
        {
            List<Artist> aList = new List<Artist>();
            Artist a1 = new Artist { ID = Guid.NewGuid(), Name = "cxk", Description = "唱跳Rab" };
            Artist a2 = new Artist { ID = Guid.NewGuid(), Name = "cxk2", Description = "唱跳Rab" };
            aList.Add(a1);
            aList.Add(a2);
            var result = aList.Contains(a2);
            var nameResult = aList.Where(x => x.Name.Contains("cxk")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            Assert.True(result);
            Assert.Equal("cxk", nameResult);
        }
    }
}
