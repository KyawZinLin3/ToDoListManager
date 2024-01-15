using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListManager
{
    public class Color
    {
        public string NL = Environment.NewLine; // shortcut
        public string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        public string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        public string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        public string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        public string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        public string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        public string ORANGE = Console.IsOutputRedirected ? "" : "\x1b[38;5;214m";
        public string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        public string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        public string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        public string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        public string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        public string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        public string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        public string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Color color = new Color();
           
            program.Menu();

          

            Console.ReadKey();
        }

        private void Menu()
        {
            Color color = new Color();
            Console.WriteLine($"{color.MAGENTA}Welcome to the{color.NORMAL}{color.ORANGE} To-Do List{color.NORMAL}{color.MAGENTA} Manager!");
            Console.WriteLine($"1. {color.ORANGE}Add {color.MAGENTA}Task");
            Console.WriteLine($"2. {color.ORANGE}View {color.MAGENTA}Tasks");
            Console.WriteLine($"3. Mark Task as {color.ORANGE}Completed");
            Console.WriteLine($"{color.MAGENTA}4. {color.ORANGE}Remove {color.MAGENTA}Task");
            Console.WriteLine($"5. {color.ORANGE}View Completed {color.MAGENTA}Tasks");
            Console.WriteLine($"6. {color.ORANGE}Save {color.MAGENTA}and {color.ORANGE}Exit");
        }

       
    }
}
