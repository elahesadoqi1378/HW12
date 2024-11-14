
using HW_Week12_End.Entties;

namespace HW_Week12_End.Contracts
{
    public interface IUserRepository
    {
        void Create(User user);
        User Get(string username , string password);
    }
}
