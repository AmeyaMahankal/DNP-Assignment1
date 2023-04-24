using Domain.Models;

namespace WebApplication1.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    
}