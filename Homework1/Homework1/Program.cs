﻿namespace Homework1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }

    public class Dish
    {
        private string _name;
        private int _price;
        private List<Ingredient> _ingredients;
        
        public string Name
        {
            get => _name;
            set
            {
                if (int.TryParse(value, out _))
                    throw new ArgumentException("It`s num");
                _name = value;
            }
        }
        
        public int Price
        {
            get => _price;
            set
            {
                if (value < 1)
                    throw new ArgumentException("It`s incorrect num");
                _price = value;
            }
        }

        public Dish(string name, int price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            _ingredients = ingredients;
        }
    }

    public class Ingredient
    {
        private string _name;
        private int _cost;
        
        
    }
    
    // public class Checking
    // {
    //     public bool isDigit(string value)
    //     {
    //         if (int.TryParse(value, out _))
    //             return true;
    //         return false;
    //     }
    // }
}

