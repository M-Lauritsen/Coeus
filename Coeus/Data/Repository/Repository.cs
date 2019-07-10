using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coeus.Models;

namespace Coeus.Data.Repository
{
    public class Repository : IRepository
    {
        private BlogDbContext _ctx;

        public Repository(BlogDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);

        }

        public List<Post> getAllPost()
        {
            return _ctx.Posts.ToList();
        }

        public Post getPost(int id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {

            _ctx.Posts.Remove(getPost(id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
