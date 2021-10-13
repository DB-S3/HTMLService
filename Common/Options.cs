using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common
{
    public class Options
    {
        [Key]
        public string Id { get; set; }
        public string ObjectId { get; set; }
        public HTMLObjects HTMLObjects { get; set; }
        public int X { get; set; }
        public string XUnit { get; set; }
        public int Y { get; set; }
        public string YUnit { get; set; }
        public int Height { get; set; }
        public string HeightUnit { get; set; }
        public int Width { get; set; }
        public string WidthUnit { get; set; }
        public string Colour { get; set; }
        public string BackgroundColour { get; set; }
        public string BorderRadius { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public string position { get; set; }

        public Options() {
            Id = Guid.NewGuid().ToString(); 
        }
    }
}
