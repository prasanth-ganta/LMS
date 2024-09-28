using System.ComponentModel.DataAnnotations;
public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;
        return date > DateTime.Now;
    }
    public override string FormatErrorMessage(string value)
    {
        return $"The DueDate {value} should be a future date.";
    }  
}