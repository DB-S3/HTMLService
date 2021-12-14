using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace Common
{
    public class ReturnPage
    {
        public string Id { get; set; }
        public string WebsiteId { get; set; }
        public List<HTMLObjects> Objects { get; set; }
        public string Name { get; set; }
        public Website Website { get; set; }
        public List<BitmapImage> Images { get; set; }

        public ReturnPage(Page page)
        {
            Objects = page.Objects;
            Images = new List<BitmapImage>();
            Id = page.Id;
            WebsiteId = page.WebsiteId;
            Name = page.Name;
            Website = page.Website;
        }
        public ReturnPage()
        {
        }
    }
}
