namespace Homework1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }

    public class ManagementRestaurant
    {
        private List<Dish> _dish;
        private List<Ingredient> _ingredients;
        private List<Employee> _employees;
        private List<Table> _tables;

        public ManagementRestaurant()
        {
            _dish = new List<Dish>();
            _ingredients = new List<Ingredient>();
            _employees = new List<Employee>();
            _tables = new List<Table>();
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

    public class Table
    {
        private int _numberTable;
        private int _numberSeats;

        public int NumberTable
        {
            get => _numberTable;
            set
            {
                if (value < 1 || value > 25)
                    throw new ArgumentException("Incorrect num for number table");
                _numberTable = value;
            }
        }

        public int NumberSeats
        {
            get => _numberSeats;
            set
            {
                if (value < 1 || value > 8)
                    throw new AggregateException("Incorrect num for number seats");
                _numberSeats = value;
            }
        }

        public Table(int numberTable, int numberSeats)
        {
            NumberTable = numberTable;
            NumberSeats = numberSeats;
        }
    }

    public class Customer
    {
        private string _nameCustomer;
        private long _numberPhone;

        public string NameCustomer
        {
            get => _nameCustomer;
            set
            {
                if (int.TryParse(value, out _))
                    throw new ArgumentException("It`s num");
                _nameCustomer = value;
            }
        }

        public long NumberPhone
        {
            get => _numberPhone;
            set
            {
                if (value.ToString().Length < 10)
                    throw new AggregateException("Incorrect phone number");
                _numberPhone = value;
            }
        }

        public Customer(string nameCustomer, long numberPhone)
        {
            NameCustomer = nameCustomer;
            NumberPhone = numberPhone;
        }
    }
}

