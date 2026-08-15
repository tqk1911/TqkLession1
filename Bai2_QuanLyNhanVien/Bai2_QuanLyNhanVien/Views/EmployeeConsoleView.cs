using System;
using System.Collections.Generic;
using Bai2_QuanLyNhanVien.Models;
using Bai2_QuanLyNhanVien.Service;
namespace Bai2_QuanLyNhanVien.Views;

public class EmployeeConsoleView
{
    private EmployeeService employeeService;
    public EmployeeConsoleView( EmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }
    public void Run()
    {
        while (true)
        {
            ShowMenu();
            Console.WriteLine("Chọn chức năng: ");
            string choice = Console.ReadLine() ??"";
            Console.Clear();
            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;

                case "2":
                    DisplayEmployees();
                    break;

                case "3":
                    DisplaySalary();
                    break;

                case "4":
                    DisplayTotalSalary();
                    break;

                case "5":
                    DisplayHighestSalary();
                    break;

                case "6":
                    DisplaySortedEmployees();
                    break;

                case "7":
                    DisplaySalaryByDepartment();
                    break;

                case "8":
                    DisplayEmployeesOverThreeYears();
                    break;

                case "9":
                    ExportMonthlySalary();
                    break;

                case "0":
                    Console.WriteLine("Đã thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
            Console.WriteLine("Nhấn Enter để tiếp tục");
            Console.ReadLine();
            Console.Clear();
        }
    }
    private void ShowMenu()
    {
         Console.WriteLine(" QUẢN LÝ NHÂN VIÊN ");
        Console.WriteLine("1. Thêm nhân viên theo từng loại");
        Console.WriteLine("2. Hiển thị danh sách nhân viên");
        Console.WriteLine("3. Tính lương từng nhân viên");
        Console.WriteLine("4. Tính tổng quỹ lương");
        Console.WriteLine("5. Tìm nhân viên có lương cao nhất");
        Console.WriteLine("6. Sắp xếp nhân viên theo lương");
        Console.WriteLine("7. Thống kê lương theo phòng ban");
        Console.WriteLine("8. Lọc nhân viên làm việc trên 3 năm");
        Console.WriteLine("9. Xuất bảng lương theo tháng");
        Console.WriteLine("0. Thoát");
    }
    private void AddEmployee()
    {
        Console.WriteLine("THÊM NHÂN VIÊN");
        Console.WriteLine("Mã nhân viên: ");
        string ma = Console.ReadLine()!;
        Console.WriteLine("Họ tên: ");
        string hoTen= Console.ReadLine()!;
        Console.WriteLine("Phòng ban: ");
        string phongBan = Console.ReadLine()!;
        Console.WriteLine("Ngày vào làm (dd/MM/yyyy): ");
        DateTime ngayVaoLam = DateTime.Parse(Console.ReadLine()!);
        Console.WriteLine("Lương cơ bản: ");
        decimal luongCoBan = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine();
        Console.WriteLine("1. Nhân viên chính thức");
        Console.WriteLine("2. Nhân viên thử việc");
        Console.WriteLine("3. Nhân viên thời vụ");
        Console.WriteLine("4. Nhân viên kinh doanh");
        Console.Write("Chọn loại nhân viên: ");
        string loai = Console.ReadLine()!;
        Employee employee;
        switch (loai)
        {
            case "1":
                Console.WriteLine("Phụ cấp: ");
                decimal phuCap = decimal.Parse(Console.ReadLine()!);
                employee = new FullTimeEmployee(
                    ma,
                    hoTen,
                    phongBan,
                    ngayVaoLam, 
                    luongCoBan,
                    phuCap);
                break; 

            case "2":
                employee = new ProbationEmployee(
                    ma, 
                    hoTen,
                    phongBan,
                    ngayVaoLam, 
                    luongCoBan);
                break;

            case "3": 
                Console.WriteLine("Số giờ làm: ");
                int soGioLam = int.Parse(Console.ReadLine()!);
                Console.Write("Đơn giá giờ: ");
                decimal donGiaGio = decimal.Parse(Console.ReadLine()!);
                employee = new PartTimeEmployee(
                    ma,
                    hoTen,
                    phongBan,
                    ngayVaoLam,
                    luongCoBan,
                    soGioLam,
                    donGiaGio);
                break;

            case "4":
                Console.WriteLine("Doanh số: ");
                decimal doanhSo = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("Tỷ lệ hoa hồng: ");
                decimal tyLeHoaHong = decimal.Parse(Console.ReadLine()!) / 100;
                employee = new SalesEmployee(
                    ma,
                    hoTen,
                    phongBan,
                    ngayVaoLam,
                    luongCoBan,
                    doanhSo,
                    tyLeHoaHong);
                break;

            default:
                Console.WriteLine("Không hợp lệ");
                return;
        }
        employeeService.AddEmployee(employee);
        Console.WriteLine("Thêm nhân viên thành công.");
    }
    private void DisplayEmployees()
    {
        Console.WriteLine("DANH SÁCH NHÂN VIÊN");
        List<Employee> employees = employeeService.GetAllEmployees();
        if(employees.Count == 0)
        {
            Console.WriteLine("Chưa có nhân viên");
            return;
        }
        foreach(Employee employee in employees)
        {
            employee.DisplayInfo();
        }
    }

    private void DisplaySalary()
    {
        Console.WriteLine("Lương nhân viên");
        List<Employee> employees = employeeService.GetAllEmployees();
        if(employees.Count == 0)
        {
            Console.WriteLine("Chưa có nhân viên");
            return;
        }
        foreach(Employee employee in employees)
        {
            Console.WriteLine(
                $"Mã Nhân viên: {employee.MaNhanVien}|"+
                $"Tên: {employee.HoTen}|"+
                $"Lương: {employee.CaculateSalary():N0}"
            );
        }
    }
    private void DisplayTotalSalary()
    {
        Console.WriteLine("Tổng quỹ lương");
        decimal total = employeeService.GetToltalSalary();
        Console.WriteLine($"Tổng quỹ lương: {total:N0}");
    }

    private void DisplayHighestSalary()
    {
        Console.WriteLine("Nhân viên có lương cao nhất");
        Employee? employee = employeeService.GetHighestSalary();
        if(employee == null)
        {
            Console.WriteLine("Chưa có nhân viên");
            return;
        }
        employee.DisplayInfo();
        Console.WriteLine($"Lương: {employee.CaculateSalary:N0}");
    }

    private void DisplaySortedEmployees()
    {
        Console.WriteLine("Sắp xếp nhân viên theo lương");
        List<Employee> employees = employeeService.SortBySalary();
        if(employees.Count == 0)
        {
            Console.WriteLine("Chưa có nhân viên");
            return;
        }
        foreach(Employee employee in employees)
        {
            Console.WriteLine(
                $"{employee.MaNhanVien} - " +
                $"{employee.HoTen} - " +
                $"{employee.CaculateSalary():N0}");
        }
    }
    
    private void DisplaySalaryByDepartment()
    {
        Console.WriteLine("Thống kê lương theo phòng ban");
        Dictionary<string, decimal> result = employeeService.GetSalaryByDepartment();
        if (result.Count == 0)
        {
            Console.WriteLine("Chưa có dữ liệu");
            return;
        }
        foreach(var item in result)
        {
            Console.WriteLine(
                $"Phòng ban: {item.Key}|"+
                $"Lương: {item.Value:N0}");
        }
    }

    private void DisplayEmployeesOverThreeYears()
    {
        Console.WriteLine("Thống kê nhân viên làm trên ba năm");
        List<Employee> employees = employeeService.GetOverThreeYear();
        if (employees.Count == 0)
        {
            Console.WriteLine("Không có nhân viên nào làm trên ba năm");
            return;
        }
        foreach(Employee employee in employees)
        {
            Console.WriteLine(
                $"{employee.MaNhanVien} - " +
                $"{employee.HoTen} - " +
                $"Ngày vào làm: {employee.NgayVaoLam:dd/MM/yyyy}");
        }
    }

    private void ExportMonthlySalary()
    {
        Console.WriteLine("Bảng lương theo tháng");
        List<Employee> employees = employeeService.GetMonthlySalary();
        if (employees.Count == 0)
        {
            Console.WriteLine("Chưa có nhân viên.");
            return;
        }

        Console.WriteLine(
            $"{"Mã NV",-10}" +
            $"{"Họ tên",-20}" +
            $"{"Phòng ban",-15}" +
            $"{"Lương",-15}");

        Console.WriteLine(new string('-', 60));

        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"{employee.MaNhanVien,-10}" +
                $"{employee.HoTen,-20}" +
                $"{employee.PhongBan,-15}" +
                $"{employee.CaculateSalary(),-15:N0}");
        }
    }
}