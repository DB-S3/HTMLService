using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WebsiteDa : IWebsiteDa
    {
        private readonly Database _db;
        public WebsiteDa(Database db) {
            _db = db;
        }

        public async Task AddWebsite(Website website)
        {
                _db.Websites.Add(website);
                _db.SaveChanges();
        }

        public async Task<int> CheckIfOwnerHasWebsite(string ownerID)
        {
                return _db.Websites.Where(x => x.OwnerId == ownerID).Count();
        }

        public async Task<int> CheckIfURLHasBeenTaken(string URL)
        {
                return _db.Websites.Where(x => x.Url == URL).Count();
        }
    }
}
