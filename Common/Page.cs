using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Page
    {
        public string Id { get; set; }
        public string WebsiteId { get; set; }
        public List<HTMLObjects> Objects { get; set; }
        public string Name { get; set; }
        public Website Website { get; set; }

        public Page() {
            Objects = new List<HTMLObjects>();
        }
    }
}
