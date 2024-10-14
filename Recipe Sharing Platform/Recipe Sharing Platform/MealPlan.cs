using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe_Sharing_Platform
{
    public class MealPlan
    {
        public DateTime Date {get;set; }
        public List<Recipe> Recipes { get; set; }= new List<Recipe>();
    }
}
