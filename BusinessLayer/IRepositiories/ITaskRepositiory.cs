using Models;
namespace BusinessLayer;
public interface ITaskRepository
{
    List<TaskDetails> GetTaskList();
    void CreateTask(TaskDetails task);
    void UpdateTaskStatus(int ID,String status);
    void UpdateTaskPriority(int ID,String task);
    bool DeleteTask(int id);
    List<TaskDetails> ShowAllTasks();
    // void SaveAllTasks(String userName);
}




