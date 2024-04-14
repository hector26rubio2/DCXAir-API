using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ApplicationValidationException : Exception
    {
        public List<string> ValidationErrors { get; }

        public ApplicationValidationException(List<ValidationFailure> failures)
            : base("La validación ha fallado. Consulta la propiedad ValidationErrors para obtener más detalles.")
        {
            ValidationErrors = new List<string>();
            foreach (var failure in failures)
            {
                ValidationErrors.Add($"'{failure.PropertyName}': {failure.ErrorMessage}");
            }
        }
    }
}
