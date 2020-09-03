using System;

namespace PA1
{
    class Post
    {
        public int postId {get; set;}
        public string postText {get; set;}
        public DateTime timestamp {get;set;}

       public Post(int id, string text, DateTime time)
        {
            postId = id;
            postText = text;
            timestamp = time;
        }
    }
}