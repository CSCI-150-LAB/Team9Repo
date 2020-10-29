using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace NutritionLog
{
    class FoodEntry
    {
        Dictionary<string, List<Food>> items; //<food name, food object>
        FoodEntry()
        {
            items.Clear();
        }

        void addNewFood(Food f)//adds new food list with item if list does not already exist
        {
            if (!items.ContainsKey(f.name))
            {
                List<Food> item;
                item.Add(f);
                items.Add(f.name, item);
            }
        }
        void addDuplicateFood(Food f)//adds duplicate item to the list of the food if already exists
        {
            if (items.ContainsKey(f.name))
            {
                List<Food> item = items[f.name];
                if (!item.Contains(f))
                {
                    item.Add(f);
                }
            }
        }

        void removeAllFood(string f)//remove entire list with specific food name
        {
            foreach (Dictionary<string, Food> item in items)
            {
                items.
            }
            items.Remove(f.);
        }
        void removeSingleFood(Food f)//removes single specific instance of item from list with that name
        {
            if (items.ContainsKey(f.name))
            {
                if (items[f.name].Contains(f))
                {
                    items[f.name].Remove(f);
                }
            }
        }

        List<Food> searchByName(string s) //searches by name of the food (key)
        {
            if (!items.ContainsKey(s))
            {
                return new List<Food>();
            }
            else
            {
                return items[s];
            }
        }

        Food searchByValue(Food f)  //search by food object (value)
        {
            if (items.ContainsKey(f.name) && items[f.name].Contains(f))
            {
                    return f;
            }
            else
            {
                return null;
            }
        }

        void updateItem(Food r, Food f) //replace at name 'r' with object 'f' if they share a name
        {
            if (r.name == f.name)
            {
                items[r.name] = f;
            }
        }

        List<string> printAll()  //put all names of food into a list and return the list
        {
            List<Food> allItems;
            List<string> result;
            foreach (var entry in items)
            {
                allItems.AddRange(entry);
            }
            for (int i = 0; i < allItems.Count(); i++)
            {
                result[i] = allItems[i].name;
            }
            return result;
        }
    }
}
