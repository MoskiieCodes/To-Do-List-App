public class TaskService
{
    private readonly ITaskRepository repository;
    private int nextId = 1;

    public TaskService(ITaskRepository repository)
    {
        this.repository = repository;
    }

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
        repository.Add(task);
    }

    public void UpdateTask(int id, string title, string description, DateTime dueDate, string priority)
    {
        var task = repository.GetById(id);
        if (task != null)
        {
            task.Title = title;
            task.Description = description;
            task.DueDate = dueDate;
            task.Priority = priority;
            repository.Update(task);
        }
    }

    public void DeleteTask(int id)
    {
        repository.Delete(id);
    }

    public void MarkTaskAsCompleted(int id)
    {
        var task = repository.GetById(id);
        if (task != null)
        {
            task.MarkAsCompleted();
            repository.Update(task);
        }
    }

    public List<TaskItem> GetTasks(bool? completed = null)
    {
        var tasks = repository.GetAll();
        if (completed == null) return tasks;
        return tasks.Where(t => t.IsCompleted == completed.Value).ToList();
    }
}
