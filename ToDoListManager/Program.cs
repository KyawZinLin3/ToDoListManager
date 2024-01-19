using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListManager
{
    //color for output
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
    //class AutoIncrement
    //{
    //    private int id = 1;
    //    public int GenerateId()
    //    {
    //        return id++;
    //    }
    //}
    class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Date { get; set; }
        public bool IsComplete { get; set; }

    }
    
    internal class Program
    {
        //Program program = new Program();
        List<Task> tasks = new List<Task>();
        
        bool status = true;
        private int id = 1;
        public int GenerateId()
        {
            return id++;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Color color = new Color();
            program.Menu();
            while (program.status)
            {
                Console.Write($"{color.MAGENTA}Enter your choice:");
                int value = int.Parse(Console.ReadLine());
                program.PerformOption(value);   

            }
            //Console.ReadKey();
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
            Console.WriteLine(" ");
        }

        private void PerformOption(int value)
        {
            switch (value)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    //status = false;
                    ViewTask();
                    break;
            }
        }

        private void AddTask()
        {
            Console.Write("Enter task name:");
            string taskName = Console.ReadLine();
            Console.Write("Enter task description:");
            string taskDescription = Console.ReadLine();
            Console.Write("Enter due date (YYYY-MM-DD):");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            List<Task> tasksJson = LoadTasks();
            Task NewTask = new Task
            {
                Id = GenerateId(),
                TaskName = taskName,
                TaskDescription = taskDescription,
                Date = dateTime,
                IsComplete = false
            };
            //List<Task> tasks = LoadTasks();
            tasksJson.Add(NewTask);
            SaveTasks(tasksJson);
            Console.WriteLine("Task added successfully!");
        }

        private void ViewTask()
        {
            List<Task> tasksJSON = LoadTasks();
            Console.WriteLine("Your To-Do List:");
            Console.WriteLine(" ");
            for(int i=0; i< tasksJSON.Count; i++)
            {
                int number = i + 1;
                Console.WriteLine(number +". Task: "+ tasksJSON[i].TaskName + ", Due:" + tasksJSON[i].Date.ToString("d-MM-yyyy") );
            }

        }
        static List<Task> LoadTasks()
        {
            
            string filePath = @"D:\tasks.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Task>>(json);
            }
            else
            {
                return new List<Task>();
            }
        }

        private void SaveTasks(List<Task> tasks)
        {
            string filePath = @"D:\tasks.json";
            string json = JsonConvert.SerializeObject(tasks,Formatting.Indented);
            File.WriteAllText(filePath,json);
        }

    }
}
