using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Routing;
using Models;
using BusinessLayer;
  
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class TaskController:ControllerBase{
      
      ITaskRepository taskRepository ;
      IUserRepository userRepository;
       
      public TaskController(ITaskRepository taskObject, IUserRepository userobject)
      {
          taskRepository = taskObject;
          userRepository = userobject;
      }
      

      [HttpPost]
      [AuthenticateFilterAttribute]
      public IActionResult CreateTask([FromBody]TaskDetails details,string userName)
      {
       taskRepository.CreateTask(details);
       return Ok();
      }
      [HttpGet]
      public IActionResult ShowAllTasks(){
        List<TaskDetails> allTasks= taskRepository.ShowAllTasks();
        if(allTasks.Count()==0) return BadRequest(new {message="Task list is Empty"});

        return Ok(allTasks);
      }

      [HttpGet]
      public IActionResult SaveAllTasks(String userName){
        List<TaskDetails>listOfTasks=taskRepository.GetTaskList();
        bool userPresent=userRepository.SaveAllTasks(userName,listOfTasks);
        if(!userPresent){
            return BadRequest(new {message="user not registered could not add tasks"});
        }

        return Ok("All Tasks saved");
      }

      [HttpPut("{id}/{status}")]
      public IActionResult UpdateTaskStatus(int id,String status) {
      taskRepository.UpdateTaskStatus(id,status);
      return Ok();
       
      }
      [HttpPut("{id}/{priority}")]
      public IActionResult UpdateTaskPriority(int id,String priority) {
      taskRepository.UpdateTaskPriority(id,priority);
      return Ok();
       
      }
      [HttpDelete]
      public IActionResult DeleteTask(int id) {
      bool taskPresent=taskRepository.DeleteTask(id);
      if(!taskPresent)return BadRequest(new {message=$"task with id {id} is not present"});

      return Ok("Task deleted");
       
      }


       [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel userDetails)
        {
            bool alreadyPresent=userRepository.CreateUser(userDetails);
            if(alreadyPresent){
                return BadRequest();
            }
            return Ok("user Added");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel userDetils)
        {
             bool userPresent=userRepository.LoginUser(userDetils);
             if(userPresent){
                 return Ok("Success");
             }
             return BadRequest(new {message="User have to register first"});
            
        }
     

  }

