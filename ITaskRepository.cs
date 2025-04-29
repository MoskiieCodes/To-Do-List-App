using System;
using System.Collections.Generic;

public interface ITaskRepository
{
    void Add(TaskItem task);
    void Update(TaskItem task);
    void Delete(int id);
    TaskItem? GetById(int id);
    List<TaskItem> GetAll();
}
