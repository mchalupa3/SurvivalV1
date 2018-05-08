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
                userFood = 50;
                userWater = 100;
                userHealth = 100;
                while (userHealth > 0 && userFood > 0 && userWater > 0)
                {




                    while (continueGame == true)
                    {


                        input = Console.ReadLine();
                        input = input.ToLower();
                        if (input == "commands")
                            commands();
                        if (input == "inventory")
                        {
                            inventory();
                        }
                        if (input == "drink water")
                            drinkWater();
                        if (input == "vitals")
                            vitals();
                        if (input == "eat")
                            eat();
                    }
                    

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
                    Console.WriteLine("Your water level was increased to " + userWater + "and you have " + waterBottles + "water bottles left.");

                }
            }


        }
        public static void death()
        {
            userFood = userFood - 3;
            userWater = userWater - 3;
        }

        public static void vitals()
        {
            Console.WriteLine("Water level: " + userWater);
            Console.WriteLine("Food level: "+ userFood);
        }

        public static void eat()
        {
            if(food == 0)
                Console.WriteLine("You have no food left!");
            else
            {
                if(userFood >= 100)
                {
                    Console.WriteLine("Your food level is full.");
                }
                else
                {
                    food = food - 1;
                    userFood = userFood + 7;
                    Console.WriteLine("Your food level was increased to " + userFood + "and you have " + food + "food left.");

                }
            }
        }



        

        
        

         
    }
}
