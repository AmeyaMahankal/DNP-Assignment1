namespace Domain.Models;

public class Post
{
    public int Id { get; set; }

    public User Poster { get; private set; }
    
    public string PostTitle { get; private set; }
    
    public string PostBody { get; private set; }

    public Post(User poster, string postTitle, string postBody)
    {
        Poster = poster;
        PostTitle = postTitle;
        PostBody = postBody;
    }
    
    private Post(){}
}