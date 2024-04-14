namespace WebAPI.Helpers
{
    public class PropertyValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public PropertyValidationError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
