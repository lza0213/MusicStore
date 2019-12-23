using MVCMusicStore2019.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCMusicStore2019.Controllers.Example
{
    public class ExmapleAlbumController : Controller
    {
        // GET: ExmapleAlbum

        public List<Album> GetALLAlbum()
        {
            List<Album> aList = new List<Album>();
            Album alb1 = new Album { ID = Guid.NewGuid(), Name = "你的答案", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 20 };
            Album alb2 = new Album { ID = Guid.NewGuid(), Name = "重生", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 100 };
            Album alb3 = new Album { ID = Guid.NewGuid(), Name = "你的答案1", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 120 };
            Album alb4 = new Album { ID = Guid.NewGuid(), Name = "你的答案2", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 20 };
            Album alb5 = new Album { ID = Guid.NewGuid(), Name = "你的答案3", Description = "国语专辑", IssueDate = DateTime.Now, Issuer = "蔡徐坤", LanguageClassification = "国语", Price = 120 };
            aList.Add(alb1);
            aList.Add(alb2);
            aList.Add(alb3);
            aList.Add(alb4);
            aList.Add(alb5);
            return aList;
        }
        public void SearchReasultList()
        {
            List<Album> list = GetALLAlbum();
            IEnumerable<Album> resultLnqList = from x in list
                                               where x.Price >= 50
                                               select x;
            IEnumerable<Album> resultLambdaList = list.Where(x => x.Price >= 50).ToList();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}