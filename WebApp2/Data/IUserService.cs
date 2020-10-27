using WebApp2.Models;

namespace WebApp2.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}
