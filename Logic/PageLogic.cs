using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PageLogic
    {
        Common.Interfaces.IPagesDA PageDataAccess;
        Common.Interfaces.IObjectDA ObjectDataAccess;

        public void AddPage(string Name, string ownerId) {
            PageDataAccess.CreatePage(new Common.Page() {Name = Name, Id= Guid.NewGuid().ToString(), Objects = new List<Common.HTMLObjects>(), OwnerId = ownerId });
        }

        public void RemovePage(string pageId, string ownerId) {
            if (PageDataAccess.CheckIfPageExists(pageId) == 1)
            {
                if (PageDataAccess.GetPageOwner(pageId) == ownerId)
                {
                    PageDataAccess.DeletePage(PageDataAccess.FindPage(pageId));
                }
            }
        }

        public void RenamePage(string pageId, string NewName, string ownerId) {
            if (PageDataAccess.CheckIfPageExists(pageId) == 1)
            {
                if (PageDataAccess.GetPageOwner(pageId) == ownerId)
                {
                    if (PageDataAccess.CheckIfPageExistsByName(NewName) == 0)
                    {
                        PageDataAccess.ChangePageName(pageId, NewName);
                    }
                }
            }
        }

        public Page ViewPage(string name)
        {
            if (PageDataAccess.CheckIfPageExistsByName(name) == 1)
            {
                Page page = PageDataAccess.FindPage(name);
                page.OwnerId = "";
                return page;
            }
            return null;
        }


        public PageLogic()
        {
            PageDataAccess = Factory.Factory.PageDataAccess();
            ObjectDataAccess = Factory.Factory.ObjectDataAccess();
        }
    }
}
