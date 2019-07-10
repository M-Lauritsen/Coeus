using Coeus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coeus.Data.Repository
{
    public interface IRepository
    {
        Post getPost(int id);
        List<Post> getAllPost();
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
    }
        
}
