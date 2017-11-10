
using Gomo.CC.EFDal;
using Gomo.CC.IDAL;
using Gomo.CC.Model;
namespace Gomo.CC.EFDAL
{

	public partial class BlogDal:BaseDal<Blog>,IBlogDal
	{
		public BlogDal(BloggingContext context)
			:base(context)
		{
		}
	}

	public partial class PostDal:BaseDal<Post>,IPostDal
	{
		public PostDal(BloggingContext context)
			:base(context)
		{
		}
	}

}


