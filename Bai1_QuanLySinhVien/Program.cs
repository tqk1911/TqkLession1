namespace Bai1_QuanLySinhVien;

public class Program
{
    public static void Main(string[] args)
    {
        StudentService studentService = new StudentService();

        StudentConsoleView view = new StudentConsoleView();

        MenuManager menuManager =
            new MenuManager(studentService, view);

        menuManager.Run();
    }
}