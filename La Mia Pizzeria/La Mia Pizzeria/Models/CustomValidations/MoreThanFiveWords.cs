using System.ComponentModel.DataAnnotations;

namespace La_Mia_Pizzeria.Models.CustomValidations
{
    public class MoreThanFiveWords : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int flag= 0;
           
            string fieldValue = (string)value;
            if(fieldValue == null || fieldValue.Split(" ").Length < 5) 
            {
                return new ValidationResult("Il campo deve contenere almeno 5 parole.");
            }
            else
            {
                return ValidationResult.Success;
            }
            

        }
    }
}
