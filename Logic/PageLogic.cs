﻿using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Logic
{
    public class PageLogic
    {
        Common.Interfaces.IPagesDA PageDataAccess;
        Common.Interfaces.IObjectDA ObjectDataAccess;

        public void AddPage(string Name, string ownerId) {
            PageDataAccess.CreatePage(new Common.Page() {Name = Name, Id= Guid.NewGuid().ToString(), Objects = new List<Common.HTMLObjects>()}, ownerId);
        }

        public void RemovePage(string pageId, string ownerId) {
            if (PageDataAccess.CheckIfPageExists(pageId) == 1)
            {
                if (PageDataAccess.GetPageOwner(pageId) == ownerId)
                {
                    PageDataAccess.DeletePage(PageDataAccess.FindPage(pageId).Result);
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

        public Page ChangePage(Page page, string ownerId)
        {
            if (PageDataAccess.CheckIfPageExistsByName(page.Id) == 1)
            {
                if (PageDataAccess.GetPageOwner(page.Id) == ownerId) {
                    PageDataAccess.ChangePageContent(page);
                }
                return page;
            }
            return null;
        }

        public async Task<List<string>> GetImagesIds(List<HTMLObjects> hTMLObjects, List<string> list) { 
            foreach (var element in hTMLObjects)
            {
                if (element.type == Common.Enums.HtmlTypes.img) {
                    list.Add(element.options.Text);
                   
                } 
                if (element.children.Count > 0) {
                    GetImagesIds(element.children, list);
                }
            }
            return list;
        }

        public async Task<Page> ViewPage(string id) {
            if (PageDataAccess.CheckIfPageExistsByName(id) == 1)
            {
                Common.Page page = await PageDataAccess.FindPage(id);
                return page;
            }
            return null;
        }

        public async Task<List<Page>> GetPages(string id)
        {
            return await PageDataAccess.GetPages(id);
        }

            public PageLogic()
        {
            PageDataAccess = Factory.Factory.PageDataAccess();
            ObjectDataAccess = Factory.Factory.ObjectDataAccess();
        }
    }
}
