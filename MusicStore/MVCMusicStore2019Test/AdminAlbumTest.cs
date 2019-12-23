using Moq;
using MVCMusicStore2019.Controllers;
using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStore;
using MVCMusicStore2019.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace MVCMusicStore2019Test
{
    public class AdminAlbumTest : IDisposable
    {
        private readonly IEntityRepository<Album> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;
        public AdminAlbumTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Album>(_context);
        }
        [Fact]
        public void AdminAlbumIndexText()
        {
            _output.WriteLine("这是AdminGenreController的Index方法的单元测试");
            var mockContext = new Mock<Controller>();
            var controller = new AdminAlbumController(_repository);
            controller.Index();
            mockContext.Verify();
        }
        Guid id;
        [Fact]
        public async Task TaskAdminAlbumCreate()
        {
            ///TaskAdminGenreCreate()方法会飘绿，因为该方法采用异步实现
            ///方法会自动检测方法实现中有无await关键字
            ///如果没有await，就会飘绿，方法就会按照同步实现
            id = Guid.NewGuid();
            //一组数据新增
            var taskList = new List<Album>();
           
           
            var albumType = new AlbumType()
            {
                ID = id,
                Name = "AlbumTypeName单元测试",
                Description = "Description单元测试"
            };
            var artist = new Artist()
            {
                ID = id,
                Name = "Artist单元测试",
                Description = "Artist单元测试"
            };
            var genre = new Genre()
            {
                ID = id,
                Name = "Genre单元测试",
                Description = "Genre单元测试"
            };
            taskList.Add(new Album()
            {
                ID = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueDate = DateTime.Now,
                Issuer="太平洋保险",
                LanguageClassification="日本",
                Urlstring="12345",
                Price=0.0M,
                Genre=genre,
                Artist=artist,
                AlbumType=albumType

            });
            var task = new Album()
            {
                ID = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueDate = DateTime.Now,
                Issuer = "太平洋保险",
                LanguageClassification = "日本",
                Urlstring = "12345",
                Price = 0.0M,
                Genre = genre,
                Artist = artist,
                AlbumType = albumType
            };
            task.Genre.ID = id;
            task.Artist.ID = id;
            task.AlbumType.ID = id;
            _repository.AddAndSave(task);

            var result = _repository.GetSingleById(id);
            Assert.NotNull(result);

        }
        [Fact]
        public void TaskAdminAlbumCreateEdit()
        {
            id = Guid.NewGuid();
            var albumType = new AlbumType()
            {
                ID = id,
                Name = "AlbumTypeName单元测试",
                Description = "Description单元测试"
            };
            var artist = new Artist()
            {
                ID = id,
                Name = "Artist单元测试",
                Description = "Artist单元测试"
            };
            var genre = new Genre()
            {
                ID = id,
                Name = "Genre单元测试",
                Description = "Genre单元测试"
            };
            var task1 = new Album()
            {
                ID = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueDate = DateTime.Now,
                Issuer = "太平洋保险",
                ArtistID = artist.ID,
                GenreID = genre.ID,
                AlbumTypeID = albumType.ID,
                LanguageClassification = "日本",
                Urlstring = "12345",
                Price = 0.0M,
                Genre = genre,
                Artist = artist,
                AlbumType = albumType
            };
            _repository.AddAndSave(task1);

            var task2 = new Album()
            {
                ID = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueDate = DateTime.Now,
                Issuer = "太平洋保险",
                ArtistID = artist.ID,
                GenreID = genre.ID,
                AlbumTypeID = albumType.ID,
                LanguageClassification = "日本",
                Urlstring = "12345",
                Price = 0.0M,
                Genre = genre,
                Artist = artist,
                AlbumType = albumType
            };
            _repository.Edit(task2);
            var result = _repository.GetSingleById(id);
            Assert.NotNull(result);
        }
        public void Dispose()
        {

        }
    }
}
