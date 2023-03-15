namespace Homework1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ManagementRestaurant managementRestaurant = new ManagementRestaurant();

            while (true)
            {
                Console.WriteLine("Choose what you want (1 - add, 2 - watch, 3 - create order, 4 - stop app)");
                string? answerUserMethods = Console.ReadLine();
            
                switch (answerUserMethods)
                {
                    case "1":
                        Console.WriteLine("Choose what you want (1 - add dish, 2 - add ingredients, 3 - add employees, 4 - add table)");
                        string? answerUserAdd = Console.ReadLine();

                        switch (answerUserAdd)
                        {
                            case "1":
                                Console.WriteLine("Enter name of dish");
                                string? dishName = Console.ReadLine();
                                
                                Console.WriteLine("Enter cost of dish");
                                int dishCost = Int32.Parse(Console.ReadLine() ?? string.Empty);

                                if (dishName != null)
                                {
                                    Dish newDish = new Dish(dishName, dishCost);
                                    managementRestaurant.AddDish(newDish);
                                }
                                else
                                {
                                    throw new NullReferenceException(dishName);
                                }

                                Console.WriteLine($"{dishName} costs {dishCost}");
                                Console.WriteLine("Dish successfully added");
                                break;
                            case "2":
                                Console.WriteLine("Enter name of ingredient");
                                string? ingredientName = Console.ReadLine();
                                
                                Console.WriteLine("Enter cost of ingredient");
                                int ingredientPrice = Int32.Parse(Console.ReadLine() ?? string.Empty);

                                if (ingredientName != null)
                                {
                                    Ingredient newIngredient = new Ingredient(ingredientName, ingredientPrice);
                                    managementRestaurant.AddIngredient(newIngredient);
                                }
                                else
                                {
                                    throw new NullReferenceException(ingredientName);
                                }

                                Console.WriteLine($"{ingredientName} costs {ingredientPrice}");
                                Console.WriteLine("Ingredient successfully added");
                                break;
                            case "3":
                                Console.WriteLine("Enter name of employee");
                                string? employeeName = Console.ReadLine();
                                
                                Console.WriteLine("Enter post of employee");
                                string? employeePost = Console.ReadLine();

                                if (employeeName != null && employeePost != null)
                                {
                                    Employee employee = new Employee(employeeName, employeePost);
                                    managementRestaurant.AddEmployee(employee);
                                }
                                else
                                {
                                    throw new NullReferenceException(employeeName);
                                }

                                Console.WriteLine($"Name: {employeeName}  Post: {employeePost}");
                                Console.WriteLine("Employee successfully added");
                                break;
                            case "4":
                                Console.WriteLine("Enter numbers of table (max value - 25)");
                                int numbersTable = Int32.Parse(Console.ReadLine() ?? string.Empty);
                                
                                Console.WriteLine("Enter numbers of seats (max value - 10)");
                                int numbersSeats = Int32.Parse(Console.ReadLine() ?? string.Empty);

                                Table newTable = new Table(numbersTable, numbersSeats);
                                managementRestaurant.AddTable(newTable);
                                
                                Console.WriteLine($"Number of table: {numbersTable}  seats: {numbersSeats}");
                                Console.WriteLine("Table successfully added");
                                break;
                            default:
                                throw new AggregateException("Incorrect answer from user");
                        }
                        
                        break;
                    case "2":
                        Console.WriteLine("Choose what you want (1 - watch dish, 2 - watch ingredients, 3 - watch employees, 4 - watch table)");
                        string? answerUserWatch = Console.ReadLine();
                        
                        switch (answerUserWatch)
                        {
                            case "1":
                                if (managementRestaurant.GetDish().Count == 0)
                                {
                                    Console.WriteLine("Dishes not added yet");
                                }
                                foreach (Dish dish in managementRestaurant.GetDish())
                                {
                                    Console.WriteLine($"- {dish.Name}, {dish.Price}");
                                }
                                break;
                            case "2":
                                if (managementRestaurant.GetIngredients().Count == 0)
                                {
                                    Console.WriteLine("Ingredients not added yet");
                                }
                                foreach (Ingredient ingredient in managementRestaurant.GetIngredients())
                                {
                                    Console.WriteLine($"- {ingredient.Name}, {ingredient.Cost}");
                                }
                                break;
                            case "3":
                                if (managementRestaurant.GetEmployee().Count == 0)
                                {
                                    Console.WriteLine("Employee not added yet");
                                }
                                foreach (Employee employee in managementRestaurant.GetEmployee())
                                {
                                    Console.WriteLine($"- {employee.Name}, Post: {employee.Post}");
                                }
                                break;
                            case "4":
                                if (managementRestaurant.GetTables().Count == 0)
                                {
                                    Console.WriteLine("Tables not added yet");
                                }
                                foreach (Table table in managementRestaurant.GetTables())
                                {
                                    Console.WriteLine($"- Table: {table.NumberTable}, Seats: {table.NumberSeats}");
                                }
                                break;
                            default:
                                throw new AggregateException("Incorrect answer from user");
                        }
                        
                        break;
                    case "3":
                        List<Dish> selectedDishes = new List<Dish>();
                        if (selectedDishes == null) throw new ArgumentNullException(nameof(selectedDishes));

                        Console.WriteLine("Inter the order number of the dish or 0 if you want stop");

                        int dishNum = 1;
                        do
                        {
                            Console.WriteLine("Блюдо {0}: ", dishNum);
                            int choice = Int32.Parse(Console.ReadLine() ?? string.Empty);
                            
                            if (choice == 0)
                            {
                                break;
                            }
                            else if (choice < 1 || choice > managementRestaurant.GetDish().Count)
                            {
                                Console.WriteLine("Некорректный выбор, попробуйте еще раз.");
                            }
                            else
                            {
                                selectedDishes.Add(managementRestaurant.GetDish()[choice - 1]);
                                dishNum++;
                            }
                        } while (true);
                        
                        managementRestaurant.CreateOrder(selectedDishes);
                        break;
                    case "4":
                        return;
                        break;
                    default:
                        throw new AggregateException("Incorrect answer from user");
                }
            }
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
        
        public void AddDish(Dish dish)
        {
            _dish.Add(dish);
        }
        
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }
        
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
        
        public void AddTable(Table table)
        {
            _tables.Add(table);
        }

        public List<Dish> GetDish()
        {
            return _dish;
        }

        public List<Ingredient> GetIngredients()
        {
            return _ingredients;
        }

        public List<Employee> GetEmployee()
        {
            return _employees;
        }

        public List<Table> GetTables()
        {
            return _tables;
        }

        public void CreateOrder(List<Dish> nameDish)
        {
            var order = new Order(nameDish);
            Console.WriteLine($"All price: {order.TotalCost}");
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

        public Dish(string name, int price)
        {
            Name = name;
            Price = price;
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
            TotalCost = 0;
            foreach (Dish dish in dishes)
            {
                TotalCost += dish.Price;
            }
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

        private Customer(string nameCustomer, long numberPhone)
        {
            NameCustomer = nameCustomer;
            NumberPhone = numberPhone;
        }
    }
}

