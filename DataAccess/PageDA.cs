using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PageDA : Common.Interfaces.IPagesDA
    {
        public void CreatePage(Common.Page newPage, string ownerID) {
            using (Database db = new Database())
            {
                db.Websites.Where(x => x.OwnerId == ownerID).FirstOrDefault().Pages.Add(newPage);
                db.SaveChanges();
            }
        }

        public int CheckIfPageExists(string pageId)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x => x.Id == pageId).Count();
            }
        }

        public int CheckIfPageExistsByName(string id)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x => x.Id == id).Count();
            }
        }

        public string GetPageOwner(string pageId)
        {
            using (Database db = new Database())
            {
                return db.Websites.Where(x=> x.Pages.Contains(db.Pages.Where(x => x.Id == pageId).FirstOrDefault())).FirstOrDefault().OwnerId;
            }
        }

        public void DeletePage(Common.Page page)
        {
            using (Database db = new Database())
            {
                db.Pages.Remove(page);
                db.SaveChanges();
            }
        }

        public async Task<Common.Page> FindPage(string Id)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x=> x.Id == Id).Include(t=> t.Objects).ThenInclude(y=> y.options).FirstOrDefault();
            }
        }

        public void AddObjectToPage(string Id, Common.HTMLObjects newObject)
        {
            using (Database db = new Database())
            {
                db.Pages.Where(x => x.Id == Id).FirstOrDefault().Objects.Add(newObject);
                db.SaveChanges();
            }
        }
        public void ChangePageName(string Id, string NewName) {
            using (Database db = new Database())
            {
                db.Pages.Where(x => x.Id == Id).FirstOrDefault().Name = NewName;
                db.SaveChanges();
            }
        }

        public void ChangePageContent(Page page)
        {
            using (Database db = new Database())
            {
                db.Pages.Where(x => x.Id == page.Id).FirstOrDefault().Objects = page.Objects;
                db.SaveChanges();
            }
        }

        public async Task<List<Page>> GetPages(string id) {
            using (Database db = new Database())
            {

                return db.Websites.Where(x => x.OwnerId == id).Include(x => x.Pages).FirstOrDefault().Pages;
            }
        }
    }
}
