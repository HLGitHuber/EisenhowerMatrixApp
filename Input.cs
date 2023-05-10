using System;

namespace EisenhowerMain
{
    public class Input
    {
        public int GetInt()
        {
            string input = Console.ReadLine();
            var index = Convert.ToInt32(input);
            return index;
        }

        public string GetStringUpper() => Console.ReadLine().ToUpper();
        
        public string GetString() => Console.ReadLine();

        public DateTime GetDeadline() => DateTime.Parse(Console.ReadLine());

        public bool GetImportance() => Console.ReadLine().ToUpper() == "Y";
    }
}