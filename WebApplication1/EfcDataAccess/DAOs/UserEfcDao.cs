using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int dtoOwnerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }
}