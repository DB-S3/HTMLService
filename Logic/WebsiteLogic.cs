using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WebsiteLogic
    {
        private readonly IWebsiteDa WebsiteDA;
        public async Task<string> CreateWebsite(string url, string owner) {
            if (await WebsiteDA.CheckIfOwnerHasWebsite(owner) < 1) {
                if (await WebsiteDA.CheckIfURLHasBeenTaken(url) < 1)
                {
                    await WebsiteDA.AddWebsite(new Common.Website() {Id = Guid.NewGuid().ToString(), OwnerId = owner, Url = url });
                    return "succes";
                }
            }
            return "fail";
        }

        public WebsiteLogic(DataAccess.Database db) {
            WebsiteDA = Factory.Factory.WebsiteDataAccess(db);
        }
    }
}
