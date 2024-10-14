using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe_Sharing_Platform
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Recipe> recipes = new List<Recipe>();
        static List<MealPlan> mealplan = new List<MealPlan>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome too the Recipe sharing Platform");
            {
                Console.WriteLine("\n1. Register\n2. Login\n3. Exit");
                var choice=Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        static void Register()
        {
            Console.WriteLine("Enter in Username");
            string Username=Console.ReadLine();
            Console.WriteLine("Enter in Password");
            string Password=Console.ReadLine();

            users.Add(new User { username=Username,password=Password });
            Console.WriteLine("User Registerd successfully");
        }
        static void Login()
        {
            Console.WriteLine("Enter in Username");
            string Username = Console.ReadLine();
            Console.WriteLine("Enter in Password");
            string Password = Console.ReadLine();

            var user = users.Find(u => u.username == Username && u.password == Password);
            if (user != null)
            {
                Console.WriteLine("Login Successfull");
                UserMenu();
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }
        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Submit Recipe\n2. View Recipes\n3. Rate Recipe\n4. Create Meal Plan\n5. Logout");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SubmitRecipe();
                        break;
                    case "2":
                        ViewRecipes();
                        break;
                    case "3":
                        RateRecipe();
                        break;
                    case "4":
                        CreateMealPlan();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        static void SubmitRecipe()
        {
            Console.WriteLine("Enter Recipe Title: ");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter Ingredients: ");
            string Ingredients = Console.ReadLine();
            Console.WriteLine("Enter Instructions: ");
            string Instructions = Console.ReadLine();

            recipes.Add(new Recipe { Title = Title, Ingredients = Ingredients, Instructions = Instructions });
            Console.WriteLine("Recipe submitted successfully!");
        }
        static void ViewRecipes()
        {
            Console.WriteLine("\nRecipes: ");
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"Title: {recipe.Title}");
                Console.WriteLine($"Ingredients: {recipe.Ingredients}");
                Console.WriteLine($"Instructions: {recipe.Instructions}");
                Console.WriteLine($"Average Rating: {GetAverageRating(recipe)}\n");
            }
        }
        static double GetAvrageRating(Recipe recipe)
        {
            if (recipe.Ratings.Count == 0) return 0;
            double total = 0;
            foreach (var rating in recipe.Ratings)
                {
                    total += rating.Score;
                }
            return total / recipe.Ratings.Count;
        }
        static void RateRecipe()
        {
            Console.WriteLine("Enter recipe Title to rate: );
            string Title= Console.ReadLine();
            var recipe=recipes.Find(r => r.Title.Equals(Title, StringComparison.OrdinalIgnoreCase));

            if(recipe !=null)
            {
                Console.Write("Enter your rating (1-5): ");
                int score = int.Parse(Console.ReadLine());
                Console.Write("Enter a comment: ");
                string comment = Console.ReadLine();

                recipe.Ratings.Add(new Rating { Score = score, Comment = comment });
                Console.WriteLine("Rating submitted successfully!");
            }
            else
            {
                Console.WriteLine("Recipe not Found");
            }

        }
        static void CreateMealPlan()
        { 
            Console.Write("Enter date for meal plan (yyyy-mm-dd): ");
            DateTime Date=DateTime.Parse(Console.ReadLine());
            MealPlan mpln=new MealPlan {Date=Date};

            while(true)
            {
                Console.Write("Enter recipe title to add to meal plan (or 'done' to finish): ");
                string Title=Console.ReadLine();
                if(Title.ToLower()=="done")break;

                var recipe= recipes.Find(r => r.Title.Equals(Title, StringComparison.OrdinalIgnoreCase));
                if (recipe !=null)
                {
                    MealPlan.recipes.Add(recipe);
                    Console.WriteLine("Recipe added to meal plan!");
                }
                else
                {
                    Console.WriteLine("Recipe not found");
                }
            }
        }
    }
}
