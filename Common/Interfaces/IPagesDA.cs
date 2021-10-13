using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IPagesDA
    {
        void CreatePage(Common.Page newPage);
        void DeletePage(Common.Page page);
        Common.Page FindPage(string Id);
        void AddObjectToPage(string Id, Common.HTMLObjects newObject);
        void ChangePageName(string Id, string NewName);
        string GetPageOwner(string pageId);
        int CheckIfPageExists(string pageId);
        int CheckIfPageExistsByName(string name);
    }
}
