using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IGenericDal<Post>
    {
        public void Delete(Post t)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Post t)
        {
            throw new NotImplementedException();
        }

        public void Update(Post t)
        {
            throw new NotImplementedException();
        }
    }
}
