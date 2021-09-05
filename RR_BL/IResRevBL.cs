using System.Collections.Generic;
using RR_BL;

namespace RR_BL
{
    public interface IResRevBL
    {
        Reviews AddReviews(Reviews reviews);
        List<Reviews> ViewReviews();
        Users AddUser(Users users);
        List<Users> ViewUsers();
        List<Restaurants> ViewRestaurants();
        

    }
}
