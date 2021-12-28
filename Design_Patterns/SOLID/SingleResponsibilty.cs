using System;
using System.Collections.Generic;

namespace Design_Patterns.SOLID
{

    //Single Class will be responsible for performing only its reponsibility

    public class SingleResponsibilty
    {
        public readonly FruitsBasket _fruitsBasket;
        public readonly Persistence _persistence;
        public SingleResponsibilty(FruitsBasket fruitsBasket, Persistence persistence)
        {
            _fruitsBasket = fruitsBasket;
            _persistence = persistence;
        }
        public string GetFruits()
        {
            _fruitsBasket.fruits.Add("Apple");
            return _persistence.PrintItemNames(_fruitsBasket.fruits);
        }
        
    }

    public class FruitsBasket
    {
        public readonly List<string> fruits = new List<string>();
        public void AddFruit(string fruitName)
        {
            fruits.Add(fruitName);
        }
        public void RemoveFruit(string fruitName)
        {
            fruits.Remove(fruitName);
        }
    }

    public class Persistence 
    {
        public string PrintItemNames(List<string> items)
        {
            return string.Join(",", items);
        }
    }
    
}
