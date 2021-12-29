using System;
using System.Collections.Generic;

namespace Design_Patterns.SOLID
{

    //The Liskov Substitution Principle in C# states that even the child object is replaced with the parent, the behavior should not be changed
    //vegtable extends fruits then object of vegetable referenced by fruit class would return vegetable list which is a violation of liskov substitution principle. 
    public class LiskovSubstitution
    {
        public Grocery _grocery;
        public LiskovSubstitution(Grocery grocery)
        {
            _grocery = grocery;
        }
        public List<string> GetGrocery()
        {
            List<string> items = new List<string>();

            // Fruits object created
            items.AddRange(_grocery.GetItemList());

            _grocery = new Vegetables();
            items.AddRange(_grocery.GetItemList());

            return items;
        }
        
    }

    public abstract class Grocery
    {
        public abstract List<string> GetItemList();
    }

    public class Fruits : Grocery
    {
        public readonly List<string> fruitItems = new List<string> { "Apple", "Orrange", "Grape" };
        public override List<string> GetItemList()
        {
            return fruitItems;
        }
    }

    public class Vegetables : Grocery
    {
        public readonly List<string> vegetableItems = new List<string> { "Carrot", "Cucumber", "Ladies Finger" };
        public override List<string> GetItemList()
        {
            return vegetableItems;
        }
    }

}
