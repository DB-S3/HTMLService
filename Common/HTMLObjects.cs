using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common
{
    public class HTMLObjects
    {
        [Key]
        public string key { get; set; }
        public string PageId { get; set; }

        public Page page { get; set; }
        public HtmlTypes type { get; set; }
        public Options options { get; set; }
        public List<HTMLObjects> children { get; set; }
        public HTMLObjects() {
            children = new List<HTMLObjects>();
            options = new Options();
            key = Guid.NewGuid().ToString();
        }
    }
}
