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
        public async Task AddWebsite(Website website)
        {
            using (Database db = new Database())
            {

                db.Websites.Add(website);
                db.SaveChanges();
            }
        }

        public async Task<int> CheckIfOwnerHasWebsite(string ownerID)
        {
            using (Database db = new Database())
            {

                return db.Websites.Where(x => x.OwnerId == ownerID).Count();
            }
        }

        public async Task<int> CheckIfURLHasBeenTaken(string URL)
        {
            using (Database db = new Database())
            {

                return db.Websites.Where(x => x.Url == URL).Count();
            }
        }
    }
}
