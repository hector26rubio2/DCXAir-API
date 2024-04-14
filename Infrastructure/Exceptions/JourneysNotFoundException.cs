namespace Infrastructure.Exceptions
{
    public  class JourneysNotFoundException : Exception
    {
        public JourneysNotFoundException(string? message) : base(message)
        {
        }
    }
}
