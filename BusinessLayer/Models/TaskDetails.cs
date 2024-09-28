using System.ComponentModel.DataAnnotations;
namespace Models;

public class TaskDetails
    {   
        [Required]
        [Range(1, 50, ErrorMessage = "ID must be between 1 and 50")]
        public int ID {get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Title cannot be longer than 20 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }

        [Required]
        [FutureDate]
        public DateTime DueDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Status cannot be longer than 20 characters")]
        public string Status { get; set; } 

        [Required]
        [StringLength(20, ErrorMessage = "Priority cannot be longer than 20 characters")]
        public string Priority { get; set; } 

        public List<string> Comments { get; set; } = new List<string>();
        public TaskDetails(int ID,String Title,String Description,DateTime DueDate,String Status,String Priority){
            this.ID=ID;
            this.Title=Title;
            this.Description=Description;
            this.DueDate=DueDate;
            this.Status=Status;
            this.Priority=Priority;
        }
    }