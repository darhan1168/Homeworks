namespace Homework1
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

        public List<Ingredient> Ingredients
        {
            get => _ingredients;
            set => _ingredients = value;
        }

        public Dish(string name, int price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }

    public class Ingredient
    {
        private string _name;
        private int _cost;

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

        public int Cost
        {
            get => _cost;
            set
            {
                if (value < 1)
                    throw new ArgumentException("It`s incorrect num");
                _cost = value;
            }
        }

        public Ingredient(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }

    public class Order
    {
        public List<Dish> Dishes { get; set; }
        public int TotalCost { get; set; }

        public Order(List<Dish> dishes)
        {
            Dishes = dishes;
            TotalCost = Dishes.Sum(dish => dish.Price);
        }
    }

    public class Employee
    {
        private string _name;
        private string _post;

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
        
        public string Post
        {
            get => _post;
            set
            {
                if (int.TryParse(value, out _))
                    throw new ArgumentException("It`s num");
                _post = value;
            }
        }

        public Employee(string name, string post)
        {
            Name = name;
            Post = post;
        }
    }
}

