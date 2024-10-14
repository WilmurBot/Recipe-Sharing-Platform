using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe_Sharing_Platform
{
    public class Recipe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public List<Rating> Ratings { get; set; }=new List<Rating>();
    }
}
