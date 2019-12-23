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
    public class AlbumTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Album _artist;
        public AlbumTest(ITestOutputHelper output)
        {
            _output = output;
            _artist = new Album();
        }
        [Fact]
        public void ArtisEntityTest()
        {
            List<Album> aList = new List<Album>();
            Album a1 = new Album { ID = Guid.NewGuid(), Name = "你的答案", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 20 };
            aList.Add(a1);
            var result = aList.Contains(a1);
            var nameResult = aList.Where(x => x.Name.Contains("你的答案")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            Assert.True(result);
            Assert.Equal("你的答案", nameResult);
        }
    }
}
