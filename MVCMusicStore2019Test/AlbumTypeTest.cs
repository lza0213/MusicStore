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
    public class AlbumTypeTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AlbumType _artist;
        public AlbumTypeTest(ITestOutputHelper output)

        {
            _output = output;
            _artist = new AlbumType();
        }
        [Fact]
        public void ArtisEntityTest()
        {
            List<AlbumType> aList = new List<AlbumType>();
            AlbumType a1 = new AlbumType { ID = Guid.NewGuid(), Name = "运动", Description = "1111" };
            aList.Add(a1);
            var result = aList.Contains(a1);
            var nameResult = aList.Where(x => x.Name.Contains("运动")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            Assert.True(result);
            Assert.Equal("运动", nameResult);
        }
    }
}
