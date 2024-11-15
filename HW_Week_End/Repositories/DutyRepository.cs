

using HW_Week_End.Entties;
using HW_Week_End.Repositories;
using HW_Week12_End.Contracts;

namespace HW_Week12_End.Repositories
{

    public class DutyRepository : IDutyRepository
    {
        private readonly AppDBContext appDBContext;

        public DutyRepository()
        {
            appDBContext = new AppDBContext();
        }

        public void Create(Duty duty)
        {
            try
            {
                appDBContext.Duties.Add(duty);
                appDBContext.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
           
        }

        public List<Duty> GetAll()
        {
            var Duties = appDBContext.Duties.ToList();
            return Duties;
            
        }

        public void Update(int id ,Duty d)
        {
            var dutyToEdit = appDBContext.Duties.FirstOrDefault(d => d.Id == id);
            dutyToEdit.Title = d.Title;
            dutyToEdit.State = d.State;
            dutyToEdit.Priority = d.Priority;
            dutyToEdit.TimeToDone = d.TimeToDone;
            appDBContext.SaveChanges(); 
        }
        public void Delete(int id)
        {
            var duty = Get(id);
            if (duty != null)
            {
                appDBContext.Duties.Remove(duty);
                appDBContext.SaveChanges(); 
            }
            else
            {
                throw new Exception("can not find duty with id " + duty.Id);
            }
        }

        public Duty FindDuty(string title)
        {
            var duties = GetAll();
            return duties.Find(duty => duty.Title==title);
        }

        public Duty Get(int id)
        {
            var duty = appDBContext.Duties.FirstOrDefault(d => d.Id == id);
            if (duty != null)
            {
                return duty;
            }
            else
            {
                throw new Exception("can not find duty with id " + duty.Id);
            }
          
        }

      
    }
}