using Bai2_QuanLyNhanVien.Service;
using Bai2_QuanLyNhanVien.Views;

namespace Bai2_QuanLyNhanVien;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeService employeeService = new EmployeeService();

        EmployeeConsoleView view =
            new EmployeeConsoleView(employeeService);

        view.Run();
    }
}