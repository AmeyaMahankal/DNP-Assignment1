using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Application.DaoInterfaces;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using FileData;
using FileData.DAOs;

namespace WebApplication1.Services;

public class AuthService : IAuthService
{

    private IUserDao userDao;

    public AuthService(IUserDao dao)
    {
        userDao = dao;
    }
    

    public async Task<User> ValidateUser(string username, string password)
    {
        User? exist = await userDao.GetByUsernameAsync(username);
       
        if (exist == null)
        {
            throw new Exception("User not found");
        }

        if (!exist.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return await Task.FromResult(exist);
    }

}