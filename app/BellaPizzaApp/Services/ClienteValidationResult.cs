using System.Collections.Generic;

namespace BellaPizzaApp.Services
{
    public class ClienteValidationResult
    {
        public bool Success { get; set; }
        public ICollection<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }

}
