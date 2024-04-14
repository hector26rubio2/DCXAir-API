using System.Text.Json;

namespace WebAPI.Helpers
{
    public class PascalCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            // Convertir el nombre a PascalCase
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
