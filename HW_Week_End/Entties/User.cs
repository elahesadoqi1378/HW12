
using HW_Week_End.Entties;

namespace HW_Week12_End.Entties
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public List<Duty> Duties { get; set; }

    }
}
