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
        private readonly DataAccess.Database _db;
        public PageDA(DataAccess.Database db) {
            _db = db;
        }

        public void CreatePage(Common.Page newPage, string ownerID)
        {
                _db.Websites.Where(x => x.OwnerId == ownerID).FirstOrDefault().Pages.Add(newPage);
                _db.SaveChanges();
        }

        public int CheckIfPageExists(string pageId)
        {
                return _db.Pages.Where(x => x.Id == pageId).Count();
        }

        public int CheckIfPageExistsByName(string id)
        {
                return _db.Pages.Where(x => x.Id == id).Count();
        }

        public string GetPageOwner(string pageId)
        {
                return _db.Websites.Where(x => x.Pages.Contains(_db.Pages.Where(x => x.Id == pageId).FirstOrDefault())).FirstOrDefault().OwnerId;
        }

        public void DeletePage(Common.Page page)
        {
                _db.Pages.Remove(page);
                _db.SaveChanges();
        }

        public async Task<Common.Page> FindPage(string Id)
        {
                return _db.Pages.Where(x => x.Id == Id).Include(t => t.Objects).ThenInclude(y => y.options).FirstOrDefault();
        }
        public async Task<string> GetDBName() {
            return _db.Database.ProviderName;
        }

        public void AddObjectToPage(string Id, Common.HTMLObjects newObject)
        {
                _db.Pages.Where(x => x.Id == Id).FirstOrDefault().Objects.Add(newObject);
                _db.SaveChanges();
        }
        public void ChangePageName(string Id, string NewName)
        {
                _db.Pages.Where(x => x.Id == Id).FirstOrDefault().Name = NewName;
                _db.SaveChanges();
        }

        public void ChangePageContent(Page page)
        {
                _db.Pages.Where(x => x.Id == page.Id).FirstOrDefault().Objects = page.Objects;
                _db.SaveChanges();
        }

        public async Task<List<Page>> GetPages(string id)
        {
                return _db.Websites.Where(x => x.OwnerId == id).Include(x => x.Pages).FirstOrDefault().Pages;
        }
    }
}
