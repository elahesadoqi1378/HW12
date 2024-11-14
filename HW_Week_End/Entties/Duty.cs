

using HW_Week_End.Enums;
using HW_Week12_End.Entties;
using System.ComponentModel.DataAnnotations;

namespace HW_Week_End.Entties
{

    public class Duty
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeToDone { get; set; }
        public int Priority { get; set; } //olaviat
        public State State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }

}
