using RR_DL.Entities;
using System;
using System.Linq;

namespace RR_UI
{
    class Menu : IMenu
    {
        private CMDBP0Context context;

        public Menu(CMDBP0Context context)
        {
            this.context = context;
        }


        public void Start()
        {
            User admin = new User();
            LoginMenu();
        }
        
        public void RevMenu(CMDBP0Context context)
        {
            bool repeat = true;
            Console.WriteLine("Welcome to C-Soned Restaurant Reviewer");
            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("0) Exit Reviewer");
                Console.WriteLine("1) View Reviews");
                Console.WriteLine("2) Add Reviews");
                Console.WriteLine("-------------------------------");
                Console.Write(">");
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Exiting Reviewer");
                        repeat = false;
                        break;
                    case "1":
                        ViewReview(context);
                        break;
                    case "2":
                        AddReview(context);
                        break;
                    default:
                        Console.WriteLine("Invalid input, Try again...");
                        break;
                }

            } while (repeat);
        }

        public void ViewReview(CMDBP0Context context)
        {
            var reviews = context.Reviews.ToList();
            if (reviews.Count == 0)
            {
                Console.WriteLine("There are no Reviews.");
            }
            else
            {
                foreach(var review in reviews)
                {
                    Console.WriteLine($"\nUser: {review.Users}");
                    Console.WriteLine($"Rating: {review.Rating} /5");
                    Console.WriteLine(review.Comments);
                }
            }
        }

        public void AddReview(CMDBP0Context context)
        {
            Review rinput = new Review(); // Instatiated input for a temporary holder for the new review
            bool validr = false;
            Console.Write("Enter Your rating out of 5: ");
            rinput.Rating = int.Parse(Console.ReadLine());
            //Validating the inpput for the rating
            if (rinput.Rating > 0 && rinput.Rating <= 5)
            {
                validr = true;
            }
            else
            {
                while (validr == false)
                {
                    Console.WriteLine("Invalid Input Try again");
                    Console.Write("\nEnter Your rating out of 5: ");
                    rinput.Rating = int.Parse(Console.ReadLine());
                    if (rinput.Rating > 0 && rinput.Rating <= 5)
                    {
                        validr = true;
                    }
                }
            }
            Console.Write("Enter additional comments: ");
            rinput.Comments = Console.ReadLine();
            context.Add(rinput);
            context.SaveChanges();
            Console.WriteLine("Review Succeessfully added");
        }

        public void LoginMenu()
        {
            bool repeat = true;
            bool success;
            Console.WriteLine("Welcome to C-Soned Restaurant Reviewer");
            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("0) Exit");
                Console.WriteLine("1) New User");
                Console.WriteLine("2) Login");
                Console.WriteLine("-------------------------------");
                Console.Write(">");
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Exiting ...");
                        repeat = false;
                        break;
                    case "1":
                        AddUser(context);
                        break;
                    case "2":
                        success = Login();
                        if(success == true)
                        {
                            ResMenu(context);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input, Try again...");
                        break;
                }

            } while (repeat);
        }
       
        public void AddUser(CMDBP0Context context)
        {
            User uinput = new User(); // Instatiated input for a temporary holder for the new user
            //bool validu = false;
            Console.WriteLine("Enter your new Username: ");
            uinput.Username = Console.ReadLine();
            //Check if username is taken
            /*for(int i=0; i< users.Count-2; i++)
            {
                if(users[i].uname == users[i+1].uname )
                {
                    while(validu == false)
                    {
                        Console.WriteLine("Username already in the system try again");
                        Console.WriteLine("Enter your new Username:");
                        if (users[i].uname != users[i + 1].uname)
                        {

                        }
                    }
                }
            }*/            
            Console.Write("Enter your new password: ");
            uinput.Password = Console.ReadLine();
            context.Add(uinput);
            context.SaveChanges();
            Console.WriteLine("User Succeessfully added");
        }
        
        public bool Login()
        {
            //Users us = new User();
            string un;
            string pw;
            bool uvalid = false;
            bool pvalid = false;
            bool valid = false;
            var users = context.Users.ToList();

            do
            {
                Console.Write("Username: ");
                un = Console.ReadLine();
                foreach (var user in users)
                {
                    if (un == user.Username)
                    {
                        uvalid = true;
                    }
                }
            } while (String.IsNullOrWhiteSpace(un));

            do
            {
                Console.Write("Password: ");
                pw = Console.ReadLine();
                foreach (var user in users)
                {
                    if (pw == user.Password) ;
                    {
                        pvalid = true;
                    }
                }
            } while (String.IsNullOrWhiteSpace(pw));

            if (uvalid == true && pvalid == true)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Username or password are incorrect");
            }
            return valid;
        }
    
        public void ResMenu(CMDBP0Context context)
        {
            bool repeat = true;
            bool success;
            bool adminprivlige = false;
            Console.WriteLine("Welcome to C-Soned Restaurant Reviewer");
            if (adminprivlige == true)
            {
                do
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Welcome to Resteraunt Selection!");
                    Console.WriteLine("0) Exit Resterant Selection");
                    Console.WriteLine("1) Display List of Restaurants");
                    Console.WriteLine("2) Search for a Restaurant");
                    Console.WriteLine("3) Search for a User");
                    Console.WriteLine("-------------------------------");
                    Console.Write(">");
                    switch (Console.ReadLine())
                    {
                        case "0":
                            Console.WriteLine("Exiting Restaurant Selection");
                            repeat = false;
                            break;
                        case "1":
                            ViewRestaurant(context);
                            break;
                        case "2":
                            success = SearchRestaurant();
                            if(success == true)
                            {
                                RevMenu(context);
                            }
                            break;
                        case "3":
                            ;
                            break;
                        default:
                            Console.WriteLine("Invalid input, Try again...");
                            break;
                    }

                } while (repeat);
            }
            else
            {
                do
                { 
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Welcome to Resteraunt Selection!");
                    Console.WriteLine("0) Exit Resterant Selection");
                    Console.WriteLine("1) Display List of Restaurants");
                    Console.WriteLine("2) Search for a Restaurant");
                    Console.WriteLine("-------------------------------");
                    Console.Write(">");
                    switch (Console.ReadLine())
                    {
                        case "0":
                            Console.WriteLine("Exiting Restaurant Selection");
                            repeat = false;
                            break;
                        case "1":
                            ViewRestaurant(context);
                            break;
                       case "2":
                            success = SearchRestaurant();
                            if(success == true)
                            {
                                RevMenu(context);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input, Try again...");
                            break;
                    }

                } while (repeat) ;
            }
        }
    
        public void ViewRestaurant(CMDBP0Context context)
        {
            var restaurants = context.Restaurants.ToList();
            decimal avgrat = 0m;
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"\n{restaurant.Name}");
                Console.WriteLine($"\n{restaurant.Location}");
                Console.WriteLine($"\n{restaurant.ZipCode}");
            }
        }
    
        public bool SearchRestaurant()
        {
            var restaurants = context.Restaurants.ToList();
            bool valid = false;
            string input;
            Console.WriteLine("Search the Resterant name: ");
            input = Console.ReadLine();
            foreach(Restaurant restaurant in restaurants)
            {
                if (input == restaurant.Name)
                {
                    Console.WriteLine("Found Restaurant!");
                    Console.WriteLine($"Name: {restaurant.Name}");
                    Console.WriteLine($"Rating: {restaurant.Rating}");
                    Console.WriteLine($"Location: {restaurant.Location}, {restaurant.ZipCode}");
                    valid = true;
                }
            }
            if(valid == false)
            {
                Console.WriteLine("Retsaurant does not exist ...");
            }
            return valid;
        }
    }
}
