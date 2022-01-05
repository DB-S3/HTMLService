using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPagesDA
    {
        void CreatePage(Common.Page newPage, string ownerID);
        void DeletePage(Common.Page page);
        Task<Common.Page> FindPage(string Id);
        void AddObjectToPage(string Id, Common.HTMLObjects newObject);
        void ChangePageName(string Id, string NewName);
        string GetPageOwner(string pageId);
        int CheckIfPageExists(string pageId);
        int CheckIfPageExistsByName(string name);
        void ChangePageContent(Page page);
        Task<List<Page>> GetPages(string id);
        Task<string> GetDBName();
    }
}
