using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly EfcFileContext context;

    public PostEfcDao(EfcFileContext context)
    {
        this.context = context;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Poster).AsQueryable();

        if (!string.IsNullOrEmpty(dto.username))
        {
            query = query.Where(post =>
                post.Poster.UserName.ToLower().Equals(dto.username.ToLower()));
        }

        if (dto.UserId != null)
        {
            query = query.Where(t => t.Poster.Id == dto.UserId);
        }

        if (!string.IsNullOrEmpty(dto.TitleContains))
        {
            query = query.Where(t =>
                t.PostTitle.ToLower().Contains(dto.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;


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