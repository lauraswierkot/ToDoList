using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnector.Connect();

            Console.WriteLine("To-do list:");

            string[] file = File.ReadAllLines(@"C:\Users\Laura\source\repos\ListaZadan\TaskDescriptions.csv");

            var tasks = new List<ToDoItem>();

            for (int i = 0; i < file.Length; i++)
            {
                string[] allData = file[i].Split(',');
                ToDoItem toDoItem = new ToDoItem(allData[0], allData[1], DateTime.Parse(allData[2]));
                DataBase.AddToDatabase(allData[0], allData[1], DateTime.Parse(allData[2]));
                tasks.Add(toDoItem);
            }

            DisplayTasks(tasks);

            string userInput1;

            Console.WriteLine("If you want to add another task, write 'NEW', to delete task 'DELETE', to see the updated list 'DISPLAY'");

            while (true)
            {
                userInput1 = Console.ReadLine();
                
                switch (userInput1)
                {
                    case "NEW":
                        CreateTask(tasks);
                        SaveIntoFile(@"C:\Users\Laura\source\repos\ListaZadan\TaskDescriptions.csv", tasks);
                        break;
                    case "DELETE":
                        Console.WriteLine("Give number of the task to be deleted");
                        int taskIndex = int.Parse(Console.ReadLine());
                        DeleteTask(tasks, taskIndex);
                        DataBase.DeleteFromDatabase(tasks[taskIndex].title, tasks[taskIndex].description, tasks[taskIndex].date);
                        SaveIntoFile(@"C:\Users\Laura\source\repos\ListaZadan\TaskDescriptions.csv", tasks);
                        break;
                    case "DISPLAY":
                        DisplayTasks(tasks);
                        break;
                    default:
                        break;
                }
            }
            

           Console.ReadLine();

        }

        static public void DeleteTask(List<ToDoItem> tasks, int taskIndex)
        {
            if (taskIndex <= 0 || taskIndex > tasks.Count)
            {
                Console.WriteLine("The given number is out of range");
            }

            else
            {
                tasks.RemoveAt(taskIndex - 1);
            }
        }

        static public void CreateTask(List<ToDoItem> tasks)
        {
            string title, description, deadline;
            Console.WriteLine("Title: ");
            title = Console.ReadLine();
            Console.WriteLine("Description");
            description = Console.ReadLine();
            Console.WriteLine("Deadline in YYYY/MM/DD format");
            deadline = Console.ReadLine();

            ToDoItem toDoItem = new ToDoItem(title, description, DateTime.Parse(deadline));
            DataBase.AddToDatabase(title, description, DateTime.Parse(deadline));
            tasks.Add(toDoItem);
        }

        static public void DisplayTasks(List<ToDoItem> tasks)
        {
            string tasksString = string.Join("\n", tasks);
            Console.WriteLine(tasksString);
        }

        static public void SaveIntoFile(string path, List<ToDoItem> tasks)
        {
            string tasksString = string.Join("\n", tasks);
            File.WriteAllText(path, tasksString);
        }

       

    }
}
