using System;

namespace Factory
{
    public class Factory
    {
        static public Common.Interfaces.IObjectDA ObjectDataAccess(DataAccess.Database db)
        {
            return new DataAccess.ObjectDA(db);
        }
        static public Common.Interfaces.IPagesDA PageDataAccess(DataAccess.Database db)
        {
            return new DataAccess.PageDA(db);
        }
        static public Common.Interfaces.IWebsiteDa WebsiteDataAccess(DataAccess.Database db)
        {
            return new DataAccess.WebsiteDa(db);
        }
    }
}
