namespace Domain.Models;

public class Post
{
    public int Id { get; set; }

    public User Poster { get; private set; }
    
    public string PostTitle { get; private set; }
    
    public string PostBody { get; private set; }
    /*
    public object IsCompleted { get; set; }
    public object Owner { get; set; }
    public object Title { get; set; }
*/
    public Post(User poster, string postTitle, string postBody)
    {
        Poster = poster;
        PostTitle = postTitle;
        PostBody = postBody;
    }
    
    private Post(){}
}