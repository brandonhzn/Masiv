using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Interfaces
{
    public interface IAuthRepository
    {
         Task<User> Register (User user, string password);
         Task<User> Login (string username, string password);    
         Task<bool> UserExists (string username);  
    }
}