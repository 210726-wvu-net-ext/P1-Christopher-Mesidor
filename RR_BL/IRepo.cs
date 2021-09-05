using System.Collections.Generic;

namespace RR_BL
{
    public interface IRepo
    {
        Reviews AddReviews(Reviews reviews);
        List<Reviews> GetReviews();
        Users AddUser(Users users);
        List<Users> GetUsers();
        List<Restaurants> GetRestaurants();
    }
}
