using DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> GetDetails(int id);
        Task<IEnumerable<ReviewDetail>> GetBooksReviews(int id);
        Task<IEnumerable<Review>> GetUsersReviews(int id);
        Task<bool> InsertReview(Review review);
        Task<bool> UpdateReview(Review review);
        Task<bool> DeleteReview(Review review,int userid);
    }
}
