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
    public class GenreTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Genre _artist;
        public GenreTest(ITestOutputHelper output)

        {
            _output = output;
            _artist = new Genre();
        }
        [Fact]
        public void ArtisEntityTest()
        {
            List<Genre> aList = new List<Genre>();
            Genre a1 = new Genre { ID = Guid.NewGuid(), Name = "R&B", Description = "1111" };
            aList.Add(a1);
            var result = aList.Contains(a1);
            var nameResult = aList.Where(x => x.Name.Contains("R&B")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            Assert.True(result);
            Assert.Equal("R&B", nameResult);
        }
    }
}
