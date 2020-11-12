using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Nutrition
{
    class FoodEntry
    {
        IDictionary<string, Food> items; //<food name, food object>
        public FoodEntry()
        {
            items = new Dictionary<string, Food>();
        }

        public void addNewFood(Food f)//adds new food list with item if list does not already exist
        {
            if (!items.ContainsKey(f.name))
            {
                items.Add(f.name, f);
            }
        }
        void addDuplicateFood(Food f)//adds duplicate item to the list of the food if already exists
        {
            if (items.ContainsKey(f.name))
            {
                items.Add(f.name, f);
            }
        }

        void removeAllFood(string f)//remove entire list with specific food name
        {
            items.Remove(f);
        }
        void removeSingleFood(Food f)//removes single specific instance of item from list with that name
        {
            if (items.ContainsKey(f.name))
            {
                items.Remove(f.name);
            }
        }

        public Food searchByName(string s) //searches by name of the food (key)
        {
            if (!items.ContainsKey(s))
            {
                return null;
            }
            else
            {
                return items[s];
            }
        }
        public bool updateItem(Food r, Food f) //replace at name 'r' with object 'f' if they share a name
        {
            if(items.ContainsKey(r.name))
            {
                items[r.name] = f;
                return true;
            }
            return false;
        }

        public List<Food> printAll()  //put all names of food into a list and return the list
        {
            List<Food> allItems = new List<Food>();
            foreach (var entry in items)
            {
                allItems.Add(entry.Value);
            }
            return allItems;
        }
    }
}
