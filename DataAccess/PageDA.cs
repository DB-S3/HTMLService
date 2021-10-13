using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class PageDA : Common.Interfaces.IPagesDA
    {
        public void CreatePage(Common.Page newPage) {
            using (Database db = new Database())
            {
                db.Pages.Add(newPage);
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

        public int CheckIfPageExistsByName(string name)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x => x.Name == name).Count();
            }
        }

        public string GetPageOwner(string pageId)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x => x.Id == pageId).FirstOrDefault().OwnerId;
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

        public Common.Page FindPage(string name)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x => x.Name == name).Include(t => t.Objects).ThenInclude(o => o.options).FirstOrDefault();
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
    }
}
