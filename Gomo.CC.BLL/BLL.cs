
using Gomo.CC.IBLL;
using Gomo.CC.IDAL;
using Gomo.CC.Model;
namespace Gomo.CC.BLL
{

	public partial class BlogService:BaseService<Blog>,IBlogService
	{
		public BlogService(IBlogDal blogdal)
			:base(blogdal)
		{
		}
	}

	public partial class PostService:BaseService<Post>,IPostService
	{
		public PostService(IPostDal postdal)
			:base(postdal)
		{
		}
	}

}


