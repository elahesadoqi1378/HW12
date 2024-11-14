
using Azure.Identity;
using HW_Week_End.Entties;
using HW_Week_End.Repositories;
using HW_Week12_End.Contracts;
using HW_Week12_End.Entties;

namespace HW_Week12_End.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext appDBContext;

        public UserRepository()
        {
            appDBContext = new AppDBContext();
        }
        public void Create(User user)
        {
            appDBContext.Users.Add(user);
            appDBContext.SaveChanges();


        }

        public User Get(string username, string password)


        {
            var user = appDBContext.Users.FirstOrDefault(user => user.UserName ==username && user.Password == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("can not find user with this id" + user.Id);
            }

        }
    }
}
