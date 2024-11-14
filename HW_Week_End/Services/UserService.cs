using HW_Week_End.Entties;
using HW_Week12_End.Contracts;
using HW_Week12_End.Entties;
using HW_Week12_End.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week12_End.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }
        public void Register(string username, string password, string email, int mobile)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                Email = email,
                Mobile = mobile,
                Duties = new List<Duty>()
            };
            userRepository.Create(user);
        }

        public User Login(string username, string password)
        {
           return userRepository.Get(username, password);
        }

    }
}
