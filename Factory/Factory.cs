using System;

namespace Factory
{
    public class Factory
    {
        static public Common.Interfaces.IObjectDA ObjectDataAccess() {
            return new DataAccess.ObjectDA();
        }
        static public Common.Interfaces.IPagesDA PageDataAccess()
        {
            return new DataAccess.PageDA();
        }
        static public Common.Interfaces.IWebsiteDa WebsiteDataAccess()
        {
            return new DataAccess.WebsiteDa();
        }
    }
}
