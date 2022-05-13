using System.ComponentModel.DataAnnotations;

namespace MammaMiaPizzaria.Utils.Validation
{
    public class PiuDiUnaParolaAttributoValidazione : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == false)
            {
                return new ValidationResult("il campo deve contenere almeno due parole");
            }

            return ValidationResult.Success;
        }
    }
}
