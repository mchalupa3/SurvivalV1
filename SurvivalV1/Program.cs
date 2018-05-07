using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalV1
{
    class Program
    {

        static double userWater;
        static int waterBottles = 3;
        static double userFood;
        static int food = 5;
        static bool continueGame = true;
        static double userHealth;




        public static void Main(string[] args)
        {
            string input;

            Console.WriteLine("Welcome to Surviaval");
            Console.WriteLine("The goal of the game is to see how long you can survive.");
            Console.WriteLine("You wake up in the middle of the woods. You need to collect food and water to survive.");
            Console.WriteLine("Type *commands* to get a list of commands.");
            while (continueGame == true)
            {
                userFood = 100;
                userWater = 100;
                userHealth = 100;
                while (userHealth > 0 && userFood > 0 && userWater > 0)
                {
                    input = Console.ReadLine();
                    input = input.ToLower();
                    // INterperet here
                    if (input == "commands")
                        commands();
                    if (input == "inventory")
                    {
                        inventory();
                    }
                    if (input == "drink water")
                        drinkWater();

                }


                Console.WriteLine("You died");
                continueGame = false;
            }


        }
        public static void commands()
        {
            Console.WriteLine("To view your inventory: inventory");
            Console.WriteLine("To check your vitals: vitals");
            Console.WriteLine("To check the time: time");

        }

        public static void inventory()
        {
            Console.WriteLine("Water Bottles left: " + waterBottles);
            Console.WriteLine("Food Left: " + food);

        }

        public static void drinkWater()
            {
            userWater = userWater + 15;
            waterBottles--;
            Console.WriteLine("You have " + waterBottles + "left.  Your water was raised to " + userWater);

            }



        

        
        

         
    }
}
