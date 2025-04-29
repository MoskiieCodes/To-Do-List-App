using System;

class Program
{
    static void Main(string[] args)
    {
        TaskService taskService = new TaskService();
        bool running = true;

        // OP Makgopela - Menu Loop
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

            string? choice = Console.ReadLine();

            switch (choice)
            {
                // OP Makgopela - Adding Tasks
                case "1":
                    Console.Write("Title: ");
                    string? titleInput = Console.ReadLine();
                    string title = titleInput ?? string.Empty;

                    Console.Write("Description: ");
                    string? descInput = Console.ReadLine();
                    string description = descInput ?? string.Empty;

                    Console.Write("Due Date (yyyy-mm-dd): ");
                    string? dueInput = Console.ReadLine();
                    DateTime dueDate = DateTime.TryParse(dueInput, out var parsedDue)
                        ? parsedDue
                        : DateTime.Now;

                    Console.Write("Priority: ");
                    string? priorityInput = Console.ReadLine();
                    string priority = priorityInput ?? "Normal";

                    taskService.AddTask(title, description, dueDate, priority);
                    break;

                // OP Makgopela - Updating Tasks
                case "2":
                    Console.Write("Task Id to Update: ");
                    string? updateIdInput = Console.ReadLine();
                    int updateId = int.TryParse(updateIdInput, out var parsedUpdateId)
                        ? parsedUpdateId
                        : -1;

                    Console.Write("New Title: ");
                    titleInput = Console.ReadLine();
                    title = titleInput ?? string.Empty;

                    Console.Write("New Description: ");
                    descInput = Console.ReadLine();
                    description = descInput ?? string.Empty;

                    Console.Write("New Due Date (yyyy-mm-dd): ");
                    dueInput = Console.ReadLine();
                    dueDate = DateTime.TryParse(dueInput, out parsedDue)
                        ? parsedDue
                        : DateTime.Now;

                    Console.Write("New Priority: ");
                    priorityInput = Console.ReadLine();
                    priority = priorityInput ?? "Normal";

                    taskService.UpdateTask(updateId, title, description, dueDate, priority);
                    break;

                // OP Makgopela - Deleting Tasks
                case "3":
                    Console.Write("Task Id to Delete: ");
                    string? deleteInput = Console.ReadLine();
                    int deleteId = int.TryParse(deleteInput, out var parsedDeleteId)
                        ? parsedDeleteId
                        : -1;
                    taskService.DeleteTask(deleteId);
                    break;

                // OP Makgopela - Marking a Task
                case "4":
                    Console.Write("Task Id to Mark Complete: ");
                    string? completeInput = Console.ReadLine();
                    int completeId = int.TryParse(completeInput, out var parsedCompleteId)
                        ? parsedCompleteId
                        : -1;
                    taskService.MarkTaskAsCompleted(completeId);
                    break;

                // OP Makgopela - Lists All Tasks
                case "5":
                    foreach (var task in taskService.GetTasks())
                        PrintTask(task);
                    break;

                // OP Makgopela - Lists Pending Tasks
                case "6":
                    foreach (var task in taskService.GetTasks(false))
                        PrintTask(task);
                    break;

                // OP Makgopela - Lists Completed Tasks
                case "7":
                    foreach (var task in taskService.GetTasks(true))
                        PrintTask(task);
                    break;

                // OP Makgopela - Exits Program
                case "0":
                    running = false;
                    break;

                // OP Makgopela - Invalid option error message
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
