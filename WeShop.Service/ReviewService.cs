using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;
using WeShop.IService;

namespace WeShop.Service
{
    public class ReviewService : BaseService<ProReview>,IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository) : base(reviewRepository)
        {
        }
    }
}
