using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
	public class PostManager : IPostService
	{
		IPostDal _postDal;

		public PostManager(IPostDal postDal)
		{
			_postDal = postDal;
		}

        public int GetPostCountByTeamId(int teamId)
        {
            using (var context = new Context()) 
            {
                var postCount = context.Posts.Where(p => p.TeamId == teamId).Count();
                return postCount;
            }
        }
        public void AddPost(Post post)
		{
			throw new NotImplementedException();
		}

		public void DeletePost(Post post)
		{
			throw new NotImplementedException();
		}

		public Post GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Post> GetList(int id)
		{
			return _postDal.GetListAll(x => x.PostId == id);
		}

        public List<Post> GetPostsWithUser()
        {
            return _postDal.GetListAllWithIncludes(p => true, p => p.User);
        }

        public void UpdatePost(Post post)
		{
			throw new NotImplementedException();
		}
	}
}
