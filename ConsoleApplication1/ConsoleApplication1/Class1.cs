using System;

namespace SharedProject1
{
    public class Class2
    {
        public static int GetValue2{get { return GetValue(); }}

        private static int GetValue()
        {
            int xddd = 0;
            Console.WriteLine("Я предлагаю тебе сыграть в игру\nТы готов?");
            string choice = Console.ReadLine();

            if (choice == "Да" | choice == "да")
            {
                Console.WriteLine("Тогда начнем!\n");
            }
            else
            {
                Console.WriteLine("Я разочаровался в тебе");
                xddd++;
            }

            Console.Clear();
            return xddd;
            
        }
    }
}