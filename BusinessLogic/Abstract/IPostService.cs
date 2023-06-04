using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IPostService
	{
        void AddPost(Post post);
        void DeletePost(Post post);
        void UpdatePost(Post post);
        List<Post> GetList(int id);
        Post GetById(int id);
    }
}
