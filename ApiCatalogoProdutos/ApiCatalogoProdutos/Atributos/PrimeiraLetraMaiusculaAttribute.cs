using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.Atributos
{
    public class PrimeiraLetraMaiusculaAttribute: ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {

                return ValidationResult.Success;
            }

            string primeiraLetraMaiuscula = value.ToString()[0].ToString().ToUpper();

            if (primeiraLetraMaiuscula == value.ToString()[ 0 ].ToString())
            {

                return ValidationResult.Success;
            }

            return new ValidationResult("A primeira letra deve ser maiúscula!");
        }

    }
}
