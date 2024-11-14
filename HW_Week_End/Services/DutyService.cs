

using HW_Week_End.Entties;
using HW_Week_End.Enums;
using HW_Week12_End.Contracts;
using HW_Week12_End.Entties;
using HW_Week12_End.Repositories;

namespace HW_Week12_End.Services
{

    public class DutyService
    {
        private readonly IDutyRepository dutyRepository;
        private static User loggedInUser;

        public DutyService()
        {
            dutyRepository = new DutyRepository();
        }

        public void CreateTask(string title, DateTime dueDate, int priority , User loggedInUser)
        {
            var duty = new Duty
            {
                Title = title,
                TimeToDone = dueDate,
                Priority = priority,
                State = State.InPending,
                UserId = loggedInUser.Id
            };
            dutyRepository.Create(duty);
        }

        public List<Duty> GetAllTasks( User loggedInUser)
        {
            return dutyRepository.GetAll();
        }

        public Duty GetTaskById(int id)
        {
            return dutyRepository.Get(id);
        }

        public void UpdateTask(int id, Duty updatedDuty)
        {
            dutyRepository.Update(id, updatedDuty);
        }

        public void DeleteTask(int id)
        {
            dutyRepository.Delete(id);
        }

        public Duty SearchTaskByTitle(string title , User loggedInUser)
        {
            return dutyRepository.FindDuty(title);
        }

        public void ChangeTaskStatus(int id, State newState)
        {
            var duty = dutyRepository.Get(id);
            duty.State = newState;
            UpdateTask(id, duty);
        }
    }

}

