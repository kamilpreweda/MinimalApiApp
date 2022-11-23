namespace MinimalApi.Models
{
    public class Records
    {
        public record AuthenticationData(string? UserName, string? Password);
        public record UserData(int Id, string FirstName, string LastName, string UserName);
    }
}
