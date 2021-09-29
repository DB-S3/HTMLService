using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PageLogic
    {
        Common.Interfaces.IPagesDA PageDataAccess;
        Common.Interfaces.IObjectDA ObjectDataAccess;

        public void AddPage(string Name) {
            PageDataAccess.CreatePage(new Common.Page() {Name = Name, Id= Guid.NewGuid().ToString(), Objects = new List<Common.HTMLObjects>(), OwnerId = "test"  });
        }

        public void RemovePage(string Id) {
            PageDataAccess.DeletePage(PageDataAccess.FindPage(Id));
        }
        public void RenamePage(string pageId, string NewName) {
            PageDataAccess.ChangePageName(pageId, NewName);
        }


        public PageLogic()
        {
            PageDataAccess = Factory.Factory.PageDataAccess();
            ObjectDataAccess = Factory.Factory.ObjectDataAccess();
        }
    }
}
