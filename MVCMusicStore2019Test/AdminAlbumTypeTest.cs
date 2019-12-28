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
   
        public class AdminAlbumTypeTest : IDisposable
        {
            private readonly IEntityRepository<AlbumType> _repository;
            private readonly MusicDbContext _context;
            private readonly ITestOutputHelper _output;
            public AdminAlbumTypeTest(ITestOutputHelper output)
            {
                _output = output;
                _context = new MusicDbContext();
                _repository = new EntityRepository<AlbumType>(_context);
            }
            [Fact]
            public void AdminAlbumTypeIndexText()
            {
                _output.WriteLine("这是AdminGenreController的Index方法的单元测试");
                var mockContext = new Mock<Controller>();
                var controller = new AdminAlbumTypeController(_repository);
                controller.Index();
                mockContext.Verify();
            }
            Guid id;
            [Fact]
            public async Task TaskAdminAlbumTypeCreate()
            {
                ///TaskAdminGenreCreate()方法会飘绿，因为该方法采用异步实现
                ///方法会自动检测方法实现中有无await关键字
                ///如果没有await，就会飘绿，方法就会按照同步实现
                id = Guid.NewGuid();
                //一组数据新增
                var taskList = new List<AlbumType>();
                taskList.Add(new AlbumType()
                {
                    ID = id,
                    Name = "AlbumType单元测试",
                    Description = "Description单元测试"
                });
                var task = new AlbumType()
                {
                    ID = id,
                    Name = "AlbumType单元测试",
                    Description = "Description单元测试"
                };
                _repository.AddAndSave(task);

                var result = _repository.GetSingleById(id);
                Assert.NotNull(result);

            }
        [Fact]
        public void TaskAdminAlbumTypeCreateEdit()
        {
            id = Guid.NewGuid();
            var task1 = new AlbumType()
            {
                ID = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task1);

            var task2 = new AlbumType()
            {
                ID = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
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
