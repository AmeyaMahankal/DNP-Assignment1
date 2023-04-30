using System.Data.Common;
using Application.DaoInterfaces;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic: IPostLogic
{

    private readonly IPostDao PostDao;
    private readonly IUserDao UserDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        PostDao = postDao;
        UserDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await UserDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Description);
        Post created = await PostDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        return PostDao.GetAsync(dto);
    }

    public async Task UpdateAsync(PostUpdateDto dto)
    {
        Post? existing = await PostDao.GetByIdAsync(dto.Id);
        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }
        
        User? user = null;
        if (dto.OwnerId != null)
        {
            user = await UserDao.GetByIdAsync((int)dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }
        }

        User userToUse = user ?? existing.Poster;
        string titleToUse = dto.Title ?? existing.PostTitle;
        string descToUse = dto.Description ?? existing.PostTitle;

        Post updated = new(userToUse, titleToUse, descToUse);
        
        {
            /*
            updated.PostTitle = titleToUse;
            updated.PostBody = descToUse;
            */
            updated.Id = existing.Id;
        }

       
        await PostDao.UpdateAsync(updated);


    }

    public async Task DeleteAsync(int id)
    {
        Post? post = await PostDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with ID {id} was not found!");
        }

        await PostDao.DeleteAsync(id);
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
    }
}