using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemeal.Model
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public Food_Category FdCtgr { get; set; }
    }

    public enum Food_Category
    {
        Drink,
        Appetizer,
        Main,
        Dessert
    }
}
