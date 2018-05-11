using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SurvivalV1
{
    class Program
    {

        static int userWater;
        static int waterBottles;
        static int userFood;
        static int food;
        static bool continueGame = true;
        static int userHealth;
        static int userWood;
        static Random rnd = new Random();
        static bool woodenAxe = false;
        static string playerName = "Michael";
        static int[] saveData;



        public static void Main(string[] args)
        {
            string input;
           
            Console.WriteLine("Welcome to Survival");
            Console.WriteLine("The goal of the game is to see how long you can survive.");
            Console.WriteLine("You wake up in the middle of the woods. You need to collect food and water to survive.");
            Console.WriteLine("You should probably gather wood and build a little shack to live in.");
            Console.WriteLine("Make sure to keep an eye on your vitals!");
            Console.WriteLine("Type *commands* to get a list of commands.");
                  
            while (continueGame == true)
            {
                userFood = 100;
                userWater = 100;
                userHealth = 100;

                Console.WriteLine("Welcome back " + playerName);
                while (userHealth > 0 && userFood > 0 && userWater > 0)
                {

                    input = Console.ReadLine();
                    input = input.ToLower();
                    if(userWater <= 25 || userFood <= 25)
                        Console.WriteLine("Your vitals are kinda low, might wanna check on that.");
                    if (input == "commands")
                        commands();
                    if (input == "inventory")
                        inventory();
                    if (input == "drink")
                        drinkWater();
                    if (input == "vitals")
                        vitals();
                    if (input == "eat")
                        eat();
                    if (input == "death")
                        death();
                    if (input == "build")
                        build();
                    if (input == "chop wood")
                        gatherWood();
                    if (input == "clear")
                        consoleClear();
                    if (input == "gather water")
                        gatherWater();
                    if (input == "gather food")
                        gatherFood();
                    if (input == "save")
                        save();
                    if (input == "load")
                        loadGame();
                    

                }


                Console.WriteLine("You died.");
                continueGame = false;
            }


        }
        public static void commands() //lists commands 
        {
            Console.WriteLine("To view your inventory: inventory                           To get wood: chop wood");
            Console.WriteLine("To check your vitals: vitals                                To get more water: collect water");
            Console.WriteLine("To check the time: time                                     To clear the console: clear");
            Console.WriteLine("To eat food: eat");
            Console.WriteLine("To drink water: drink");
            Console.WriteLine("To build: build");

        }

        public static void inventory() // displays inventory 
        {
            Console.WriteLine("Water Bottles left: " + waterBottles);
            Console.WriteLine("Food Left: " + food);
            Console.WriteLine("Wood: " + userWood);

        }

        public static void drinkWater() //drinking water
        {
            if (waterBottles == 0)
                Console.WriteLine("You have no water left!");
            else
            {
                if (userWater >= 100)
                {
                    Console.WriteLine("Your water level is full.");
                }
                else
                {
                    waterBottles = waterBottles - 1;
                    userWater = userWater + 10;
                    Console.WriteLine("Your water level was increased to " + userWater + " and you have " + waterBottles + " water bottles left.");

                }
            }


        }
        public static void death()
        {
            userFood = userFood - 100;
            userWater = userWater - 100;
        }

        public static void vitals() //check vitals
        {
            Console.WriteLine("Water level: " + userWater);
            Console.WriteLine("Food level: " + userFood);
        }

        public static void eat()  //Methood for eating food 
        {
            if (food == 0)
                Console.WriteLine("You have no food left!");
            else
            {
                if (userFood >= 100)
                {
                    Console.WriteLine("Your food level is full.");
                }
                else
                {
                    food = food - 1;
                    userFood = userFood + 7;
                    Console.WriteLine("Your food level was increased to " + userFood + " and you have " + food + " food left.");

                }
            }
        }
        public static void travel()
        {

        }

        public static void build()

        {
            string input;
            Console.WriteLine("Welcome to the build menu. Use *exit* to exit the menu.");
            Console.WriteLine("What would you like to build?");
            Console.WriteLine("Small TeePee: 25 wood");
            Console.WriteLine("Wooden Axe: 100 wood:");
            while(continueGame == true)
            {
                input = Console.ReadLine();
                input = input.ToLower();
                if(input == "small teepee")
                {
                    if(userWood >= 25)
                    {
                        userWood = userWood - 25;
                        Console.WriteLine("You have built a Small TeePee. You have " + userWood + " wood remaining.");
                    }
                    else
                        Console.WriteLine("You do not have enough wood" );
                }
                if (input == "exit")
                {
                    Console.WriteLine("You have left the build menu");
                    continueGame = false;
                }
                if(input == "wooden axe")
                {
                    if(userWood >= 100)
                    {
                        userWood = userWood - 100;
                        Console.WriteLine("You now have a wooden axe!");
                        woodenAxe = true;
                    }
                }

            }

        }
        public static void gatherWood()
        {
            if (woodenAxe == false)
            {


                int woodRand = rnd.Next(4, 8);
                userWater = userWater - 5;
                userFood = userFood - 5;
                userWood = userWood + woodRand;
                Console.WriteLine("You gathered " + woodRand + " wood.");
            }
            else
            {
                int woodRand = rnd.Next(10, 12);
                userWater = userWater - 7;
                userFood = userFood - 7;
                userWood = userWood + woodRand;
                Console.WriteLine("You gathered " + woodRand + " wood.");

            }

        }
        public static void consoleClear()
        {
            Console.Clear();
        }
        public static void gatherWater()
        {
            waterBottles++;
            Console.WriteLine("You have filled one bottle of water, you now have " + waterBottles);
        }
        public static void gatherFood()
        {
            int foodRand = rnd.Next(0, 4);
            food = food + foodRand;
            if (foodRand > 1)
            {
                Console.WriteLine("You found " + foodRand + " pieces of food and now have " + food + " food.");
            }
            else
                Console.WriteLine("You found " + foodRand + " piece of food and now have " + food + " food.");
            userWater = userWater -3;

        }
        public static void save()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\mchal\Desktop\test.txt");
                sw.WriteLine(userWater);
                sw.WriteLine(userFood);
                sw.WriteLine(userHealth);
                sw.WriteLine(food);
                sw.WriteLine(waterBottles);
                sw.WriteLine(userWood);
                sw.Close();

            }

            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            finally
            {
                Console.WriteLine("Your game was saved");
                
            }
        }
        public static void loadGame()
        {
            StreamReader sr = new StreamReader(@"C:\Users\mchal\Desktop\test.txt");
            userWater = Convert.ToInt32(sr.ReadLine());
            userFood = Convert.ToInt32(sr.ReadLine());
            userHealth = Convert.ToInt32(sr.ReadLine());
            food = Convert.ToInt32(sr.ReadLine());
            waterBottles = Convert.ToInt32(sr.ReadLine());
            userWood = Convert.ToInt32(sr.ReadLine());
            sr.Close();
      
        }
        

        
        

         
    }
}
