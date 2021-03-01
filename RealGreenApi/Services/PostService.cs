using RealGreenApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGreenApi.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (var a = 0; a < 5; a++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {a}"
                });
            }
        }

        public bool DeletePost(Guid postId)
        {
            var post = GetPostById(postId);

            if (post == null)
                return false;

            _posts.Remove(post);

            return true;
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(post => post.Id == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public bool UpdatePost(Post postUpdate)
        {
            var exists = GetPostById(postUpdate.Id) != null;

            if (!exists)
                return false;

            var index = _posts.FindIndex(post => post.Id == postUpdate.Id);
            _posts[index] = postUpdate;

            return true;

        }

    }
}
