using System;

class Program
{
    static void Main(string[] args)
    {
        TaskService taskService = new TaskService();
        bool running = true;

        //OP Makgopela - Menu Loop
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Update Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark Task as Completed");
            Console.WriteLine("5. List All Tasks");
            Console.WriteLine("6. List Pending Tasks");
            Console.WriteLine("7. List Completed Tasks");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {  //OP Makgopela - Adding Tasks
                case "1":
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Due Date (yyyy-mm-dd): ");
                    DateTime due = DateTime.Parse(Console.ReadLine());
                    Console.Write("Priority: ");
                    string priority = Console.ReadLine();
                    taskService.AddTask(title, desc, due, priority);
                    break;

                //OP Makgopela - Updating Tasks
                case "2":
                    Console.Write("Task Id to Update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("New Title: ");
                    title = Console.ReadLine();
                    Console.Write("New Description: ");
                    desc = Console.ReadLine();
                    Console.Write("New Due Date (yyyy-mm-dd): ");
                    due = DateTime.Parse(Console.ReadLine());
                    Console.Write("New Priority: ");
                    priority = Console.ReadLine();
                    taskService.UpdateTask(updateId, title, desc, due, priority);
                    break;

                //OP Makgopela - Deleting Tasks
                case "3":
                    Console.Write("Task Id to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    taskService.DeleteTask(deleteId);
                    break;

                //OP Makgopela - Marking a Task
                case "4":
                    Console.Write("Task Id to Mark Complete: ");
                    int completeId = int.Parse(Console.ReadLine());
                    taskService.MarkTaskAsCompleted(completeId);
                    break;

                //OP Makgopela - Lists All Tasks
                case "5":
                    foreach (var task in taskService.GetTasks())
                        PrintTask(task);
                    break;

                //OP Makgopela - Lists Pending Tasks
                case "6":
                    foreach (var task in taskService.GetTasks(false))
                        PrintTask(task);
                    break;

                //OP Makgopela - Lists Completed Tasks
                case "7":
                    foreach (var task in taskService.GetTasks(true))
                        PrintTask(task);
                    break;

                //OP Makgopela - Exits Program
                case "0":
                    running = false;
                    break;

                //OP Makgopela - Invalid option error message
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void PrintTask(TaskItem task)
    {
        Console.WriteLine($"[{task.Id}] {task.Title} - {(task.IsCompleted ? "Completed" : "Pending")}");
    }
}
