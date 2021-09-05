using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RR_BL;
using RR_DL.Entities;

namespace RR_DL
{
    public class Repo : IRepo
    {
        private readonly CMDBP0Context _context;
        public Repo(CMDBP0Context context)
        {
            _context = context;
        }

        public Reviews AddReviews(Reviews reviews)
        {
            _context.Reviews.Add(
                new Entities.Review
                {
                    Id = reviews.ID,
                    Users = reviews.UID,
                    Restaurant = reviews.RID,
                    Rating = reviews.Rating,
                    Comments = reviews.Comment
        }
            );
            _context.SaveChanges();

            return reviews;
        }

        public Users AddUser(Users users)
        {
            _context.Users.Add(
                new Entities.User
                {
                    Username = users.uname
                }
            );
            _context.SaveChanges();

            return users;
        }

        public List<Restaurants> GetRestaurants()
        {
            return _context.Restaurants.Select(
                restaurants => new RR_BL.Restaurants(restaurants.Id, restaurants.Name, restaurants.Rating, restaurants.Location, restaurants.ZipCode)
            ).ToList();
        }

        public List<RR_BL.Reviews> GetReviews()
        {
            return _context.Reviews.Select(
                reviews => new RR_BL.Reviews(reviews.Id, reviews.Users, reviews.Restaurant, reviews.Rating, reviews.Comments)
            ).ToList();
        }

        public List<Users> GetUsers()
        {
            return _context.Users.Select(
                users => new RR_BL.Users(users.Id, users.Username, users.Password, users.Admin)
            ).ToList();
        }
    }
}
