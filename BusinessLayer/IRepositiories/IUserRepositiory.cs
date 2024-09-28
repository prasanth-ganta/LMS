using Models;
namespace BusinessLayer;

public interface IUserRepository
{
    
    bool CreateUser(RegisterModel userDetails);
    bool LoginUser(LoginModel loginDetails);
    bool SaveAllTasks(String userName,List<TaskDetails>listOfTasks);
    bool LoadAllTasks(Dictionary<String,List<TaskDetails>>dataBase);
    bool UserExists(String userName);
    
}