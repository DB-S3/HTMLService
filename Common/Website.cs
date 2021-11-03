using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Website
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string OwnerId { get; set; }
        public List<Page> Pages { get; set; }

        public Website() {
            Id = Guid.NewGuid().ToString();
            Pages = new List<Page>();
        }
    }
}
