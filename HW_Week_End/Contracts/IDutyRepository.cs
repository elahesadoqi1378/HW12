

using HW_Week_End.Entties;

namespace HW_Week12_End.Contracts
{
    public interface IDutyRepository
    {
        void Create(Duty duty);
        List<Duty> GetAll();
        void Update(int id ,Duty d);
        void Delete(int id);
        Duty Get(int id);
        Duty FindDuty(string pretitle);
    }
}
