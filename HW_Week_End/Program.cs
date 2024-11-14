using HW_Week_End.Entties;
using HW_Week_End.Enums;
using HW_Week12_End.Entties;
using HW_Week12_End.Repositories;
using HW_Week12_End.Services;

//class Program
//{
//    private static DutyService dutyService;

//    static void Main(string[] args)
//    {
//        dutyService = new DutyService(new DutyRepository());
//        string choice;
//        do
//        {
//            Console.WriteLine("TODO List Management");
//            Console.WriteLine("1. Create a new task");
//            Console.WriteLine("2. Display the list of tasks");
//            Console.WriteLine("3. Edit a task");
//            Console.WriteLine("4. Delete a task");
//            Console.WriteLine("5. Change the status of a task");
//            Console.WriteLine("6. Search for a task by title");
//            Console.WriteLine("0. Exit");
//            Console.Write("Choose an option: ");
//            choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":
//                    CreateTask();
//                    break;
//                case "2":
//                    DisplayTasks();
//                    break;
//                case "3":
//                    EditTask();
//                    break;
//                case "4":
//                    DeleteTask();
//                    break;
//                case "5":
//                    ChangeTaskStatus();
//                    break;
//                case "6":
//                    SearchTask();
//                    break;
//                case "0":
//                    Console.WriteLine("Exiting the program...");
//                    break;
//                default:
//                    Console.WriteLine("Invalid option. Please try again.");
//                    break;
//            }
//        } while (choice != "0");
//    }

//    private static void CreateTask()
//    {
//        try
//        {
//            Console.Write("Enter task title: ");
//            string title = Console.ReadLine();
//            Console.Write("Enter due date (yyyy-mm-dd): ");
//            DateTime dueDate = DateTime.Parse(Console.ReadLine());
//            Console.Write("Enter priority: ");
//            int priority = int.Parse(Console.ReadLine());

//            dutyService.CreateTask(title, dueDate, priority);
//            Console.WriteLine("Task added successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private static void DisplayTasks()
//    {
//        var duties = dutyService.GetAllTasks();
//        Console.WriteLine("List of Tasks:");
//        foreach (var duty in duties)
//        {
//            Console.WriteLine($"ID: {duty.Id}, Title: {duty.Title}, Due Date: {duty.TimeToDone.ToShortDateString()}, Priority: {duty.Priority}, Status: {duty.State}");
//        }
//    }

//    private static void EditTask()
//    {
//        Console.Write("Enter task ID to edit: ");
//        int id = int.Parse(Console.ReadLine());

//        try
//        {
//            var duty = dutyService.GetTaskById(id);
//            Console.Write("Enter new title (leave empty to keep the same): ");
//            string title = Console.ReadLine();
//            if (!string.IsNullOrEmpty(title))
//                duty.Title = title;

//            Console.Write("Enter new due date (yyyy-mm-dd, leave empty to keep the same): ");
//            string dueDateInput = Console.ReadLine();
//            if (!string.IsNullOrEmpty(dueDateInput))
//                duty.TimeToDone = DateTime.Parse(dueDateInput);

//            Console.Write("Enter new priority (leave empty to keep the same): ");
//            string priorityInput = Console.ReadLine();
//            if (!string.IsNullOrEmpty(priorityInput))
//                duty.Priority = int.Parse(priorityInput);
//                dutyService.UpdateTask(id, duty);
//            Console.WriteLine("Task updated successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private static void DeleteTask()
//    {
//        Console.Write("Enter task ID to delete: ");
//        int id = int.Parse(Console.ReadLine());

//        try
//        {
//            dutyService.DeleteTask(id);
//            Console.WriteLine("Task deleted successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private static void ChangeTaskStatus()
//    {
//        Console.Write("Enter task ID to change status: ");
//        int id = int.Parse(Console.ReadLine());

//        try
//        {
//            Console.Write("Enter new status (1 - InPending, 2 - Done, 3 - Cancelled): ");
//            int statusInput = int.Parse(Console.ReadLine());
//            if (Enum.IsDefined(typeof(State), statusInput))
//            {
//                dutyService.ChangeTaskStatus(id, (State)statusInput);
//                Console.WriteLine("Task status updated successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid status option.");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private static void SearchTask()
//    {
//        Console.Write("Enter task title to search: ");
//        string title = Console.ReadLine();
//        Duty duty = dutyService.SearchTaskByTitle(title);

//        if (duty != null)
//        {
//            Console.WriteLine($"Found Task: ID: {duty.Id}, Title: {duty.Title}, Due Date: {duty.TimeToDone.ToShortDateString()}, Priority: {duty.Priority}, Status: {duty.State}");
//        }
//        else
//        {
//            Console.WriteLine("No task found with that title.");
//        }
//    }
//}
class Program
{
    private static DutyService dutyService;
    private static UserService userService;
    private static User loggedInUser;

    static void Main(string[] args)
    {
        userService = new UserService();
        dutyService = new DutyService();

       
        LoginOrRegister();

        if (loggedInUser == null)
            return;

        string choice;
        do
        {
            Console.WriteLine("TODO List Management");
            Console.WriteLine("1. Create a new task");
            Console.WriteLine("2. Display the list of tasks");
            Console.WriteLine("3. Edit a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Change the status of a task");
            Console.WriteLine("6. Search for a task by title");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    DisplayTasks();
                    break;
                case "3":
                    EditTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    ChangeTaskStatus();
                    break;
                case "6":
                    SearchTask();
                    break;
                case "0":
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != "0");
    }

    private static void LoginOrRegister()
    {
        string choice;
        do
        {
            Console.WriteLine("Welcome! Please choose an option:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != "0" && loggedInUser == null);
    }

    private static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        loggedInUser = userService.Login(username, password);
        if (loggedInUser != null)
        {
            Console.WriteLine($"Welcome {loggedInUser.UserName}!");
        }
        else
        {
            Console.WriteLine("Login failed. Please try again.");
        }
    }

    private static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter mobile number: ");
        int mobile = int.Parse(Console.ReadLine());

        try
        {
            userService.Register(username, password, email, mobile);
            Console.WriteLine("Registration successful. You can now login.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Registration failed: {ex.Message}");
        }
    }

    private static void CreateTask()
    {
        try
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();
            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter priority: ");
            int priority = int.Parse(Console.ReadLine());
            dutyService.CreateTask(title, dueDate, priority, loggedInUser);
            Console.WriteLine("Task added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DisplayTasks()
    {
        var duties = dutyService.GetAllTasks(loggedInUser);
        Console.WriteLine("List of Tasks:");
        foreach (var duty in duties)
        {
            Console.WriteLine($"ID: {duty.Id}, Title: {duty.Title}, Due Date: {duty.TimeToDone.ToShortDateString()}, Priority: {duty.Priority}, Status: {duty.State}");
        }
    }

    private static void EditTask()
    {
        Console.Write("Enter task ID to edit: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            var duty = dutyService.GetTaskById(id);
            Console.Write("Enter new title (leave empty to keep the same): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title))
                duty.Title = title;

            Console.Write("Enter new due date (yyyy-mm-dd, leave empty to keep the same): ");
            string dueDateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(dueDateInput))
                duty.TimeToDone = DateTime.Parse(dueDateInput);

            Console.Write("Enter new priority (leave empty to keep the same): ");
            string priorityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priorityInput))
                duty.Priority = int.Parse(priorityInput);

            dutyService.UpdateTask(id, duty);
            Console.WriteLine("Task updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteTask()
    {
        Console.Write("Enter task ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            dutyService.DeleteTask(id);
            Console.WriteLine("Task deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ChangeTaskStatus()
    {
        Console.Write("Enter task ID to change status: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            Console.Write("Enter new status (1 - InPending, 2 - Done, 3 - Cancelled): ");
            int statusInput = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(State), statusInput))
            {
                dutyService.ChangeTaskStatus(id, (State)statusInput);
                Console.WriteLine("Task status updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid status option.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SearchTask()
    {
        Console.Write("Enter task title to search: ");
        string title = Console.ReadLine();
        Duty duty = dutyService.SearchTaskByTitle(title, loggedInUser);

        if (duty != null)
        {
            Console.WriteLine($"Found Task: ID: {duty.Id}, Title: {duty.Title}, Due Date: {duty.TimeToDone.ToShortDateString()}, Priority: {duty.Priority}, Status: {duty.State}");
        }
        else
        {
            Console.WriteLine("No task found with that title.");
        }
    }
}