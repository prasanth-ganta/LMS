using Models;
using System.Text.Json;
namespace BusinessLayer;
public class UserRepositiory : IUserRepository
{
    Dictionary<String,List<TaskDetails>>dataBase=new Dictionary<string, List<TaskDetails>>();
    public bool CreateUser(RegisterModel userDetails)
    {
        
        List<RegisterModel> registerList = LoadFromFile();
        if (registerList.Any(u => u.Username == userDetails.Username || u.Email == userDetails.Email))
        {
            return true;
        }

         registerList.Add(userDetails);
         UserRepositiory.SaveToFile(registerList);
         return false;
      
    }
    public bool LoginUser(LoginModel loginDetails)
    {
       List<RegisterModel> registerList = UserRepositiory.LoadFromFile();
       RegisterModel? user = registerList.FirstOrDefault(u => u.Username == loginDetails.Username && u.Password == loginDetails.Password);
       
        if (user != null)
        {
          return true;
        }
        return false;

     }

    public static void SaveToFile(List<RegisterModel>registerList)
    {
       string json = JsonSerializer.Serialize(registerList);
       File.WriteAllText("C:\\Dotnet_Prac\\Assignment26\\Database\\UserData.json",json);

    }
    public static List<RegisterModel> LoadFromFile()
    {
        
        string json=File.ReadAllText("C:\\Dotnet_Prac\\Assignment26\\Database\\UserData.json");
        List<RegisterModel> registerList =  JsonSerializer.Deserialize<List<RegisterModel>>(json);
        return  registerList;
    }

    public bool UserExists(String userName)
    {
        List<RegisterModel> registerList = LoadFromFile();
        foreach(RegisterModel user in registerList){
            if(user.Username.Equals(userName))return true;
        }
        return false;
    }

    public bool SaveAllTasks(String userName,List<TaskDetails>listOfTasks)
    {
      if(! UserExists(userName)){
        return false;
      }
      if(dataBase.ContainsKey(userName)){
        dataBase[userName]=listOfTasks;
      }else{
        dataBase.Add(userName,listOfTasks);
      }

      string json = JsonSerializer.Serialize(dataBase);
      File.WriteAllText("C:\\Dotnet_Prac\\Assignment26\\Database\\UsersTaskDatabase.json",json);
      
      return true;
      
    }

    public  bool LoadAllTasks(Dictionary<String,List<TaskDetails>>dataBase)
    {
      string json=File.ReadAllText("C:\\Dotnet_Prac\\Assignment26\\Database\\UsersTaskDatabase.json");
      dataBase=JsonSerializer.Deserialize<Dictionary<String,List<TaskDetails>>>(json);
      return true;
    }
        
        

   
}
