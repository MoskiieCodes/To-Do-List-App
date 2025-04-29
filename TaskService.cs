using System;
using System.Collections.Generic;
using System.Linq;

public class TaskService
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private int nextId = 1;

    //OP Makgopela - Add Task method
    public void AddTask(string title, string description, DateTime dueDate, string priority)
    {
        var task = new TaskItem
        {
            Id = nextId++,
            Title = title,
            Description = description,
            DueDate = dueDate,
            Priority = priority,
            IsCompleted = false
        };
        tasks.Add(task);
    }

    //OP Makgopela - Update Task method
    public void UpdateTask(int id, string title, string description, DateTime dueDate, string priority)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Title = title;
            task.Description = description;
            task.DueDate = dueDate;
            task.Priority = priority;
        }
    }

    //OP Makgopela - Delete Task method
    public void DeleteTask(int id)
    {
        tasks.RemoveAll(t => t.Id == id);
    }

    //OP Makgopela - Mark task Method
    public void MarkTaskAsCompleted(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.MarkAsCompleted();
        }
    }

    //OP Makgopela - Filtering method
    public List<TaskItem> GetTasks(bool? completed = null)
    {
        if (completed == null)
            return tasks;
        return tasks.Where(t => t.IsCompleted == completed.Value).ToList();
    }
}
