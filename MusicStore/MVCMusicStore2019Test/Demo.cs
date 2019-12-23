using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace MVCMusicStore2019Test
{
 
    public class Demo
    {
        public Demo()
        {
            this.isNew = true;
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CalculateResullt { get; set; }
        public bool isNew { get; set; }
        public void Add (int x,int y)
        {
            this.CalculateResullt = x + y;
        }
        [Fact]
        public void TestMethod1()
        {
            var demo = new Demo();
            demo.Add(5, 9);
            var result = demo.CalculateResullt;
            Assert.Equal(14, result);
        }
        [Fact]
        public void IsNewWhenCreated()
        {
            //Arrange
            var demo = new Demo();
            //Act
            var result = demo.isNew;
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void DemoForName()
        {
            var demo = new Demo
            {
                ID = Guid.NewGuid(),
                Name="李四",
                Description="信息"
            };
            var result = demo.Name;
            Assert.Equal("李四", result);

        }
    }
}
