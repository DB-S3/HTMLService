using System;

namespace Factory
{
    public class Factory
    {
        static public DataAccess.ObjectDA ObjectDataAccess() {
            return new DataAccess.ObjectDA();
        }
        static public DataAccess.PageDA PageDataAccess()
        {
            return new DataAccess.PageDA();
        }
    }
}
