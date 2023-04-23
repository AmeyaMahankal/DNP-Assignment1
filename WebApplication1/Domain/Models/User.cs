﻿namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Role { get; set; }
    
    public ICollection<Post> Posts { get; set; }
}