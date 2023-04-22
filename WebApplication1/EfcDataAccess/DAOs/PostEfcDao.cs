using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    public Task<Post> CreateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post updated)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}