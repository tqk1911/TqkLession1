using System;
using System.Collections.Generic;
namespace Bai1_QuanLySinhVien;
public class MenuManager
{
    private readonly StudentService studentService;
    private readonly StudentConsoleView view;
    public MenuManager(StudentService studentService, StudentConsoleView view)
    {
        this.studentService = studentService;
        this.view = view;
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
                    AddStudent();
                    break;

                case "2":
                    DisplayAll();
                    break;

                case "3":
                    FindById();
                    break;

                case "4":
                    SearchByName();
                    break;

                case "5":
                    UpdateStudent();
                    break;

                case "6":
                    DeleteStudent();
                    break;

                case "7":
                    SortByName();
                    break;

                case "8":
                    SortByGPA();
                    break;

                case "9":
                    DisplayGPAFrom8();
                    break;

                case "10":
                    DisplayHighestGPA();
                    break;

                case "11":
                    DisplayAverageGPA();
                    break;

                case "12":
                    StatisticsByMajor();
                    break;

                case "13":
                    StatisticsByStatus();
                    break;

                case "0":
                    Console.WriteLine("Đã thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
            Console.WriteLine("\nNhấn Enter để tiếp tục");
            Console.ReadLine();
            Console.Clear();
        }
    }
    
    private void ShowMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("       QUẢN LÝ SINH VIÊN");
        Console.WriteLine("==========================================");
        Console.WriteLine("1.  Thêm sinh viên");
        Console.WriteLine("2.  Hiển thị danh sách");
        Console.WriteLine("3.  Tìm sinh viên theo mã");
        Console.WriteLine("4.  Tìm gần đúng theo họ tên");
        Console.WriteLine("5.  Cập nhật sinh viên");
        Console.WriteLine("6.  Xóa sinh viên");
        Console.WriteLine("7.  Sắp xếp theo họ tên");
        Console.WriteLine("8.  Sắp xếp theo điểm trung bình");
        Console.WriteLine("9.  Hiển thị sinh viên có điểm từ 8");
        Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
        Console.WriteLine("11. Tính điểm trung bình toàn bộ");
        Console.WriteLine("12. Thống kê sinh viên theo ngành");
        Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
        Console.WriteLine("0.  Thoát");
        Console.WriteLine("==========================================");
        Console.WriteLine($"Tổng số sinh viên: {Student.TotalStudents}");
    }
    private void AddStudent()
    {
        Student student = view.InputStudent();
        if (studentService.AddStudent(student))
        {
            Console.WriteLine("Thêm thành công");
        }
        else
        {
            Console.WriteLine("Mã sinh viên đã tồn tại");
        }
    }
    private void DisplayAll()
    {
        view.DisplayStudents(
            studentService.GetAlltudents());
    }

    private void FindById()
    {
        Console.WriteLine("Nhập mã sinh viên: ");
        string ma = Console.ReadLine() ??"";
        Student? student = studentService.GetStudentById(ma);
        if(student == null)
        {
            Console.WriteLine("Không tìm thấy sinh viên");
            return;
        }
        view.DisplayStudents(student);
    }

    private void SearchByName()
    {
        Console.WriteLine("Nhapak họ tên cần tìm: ");
        string hoTen = Console.ReadLine() ??"";
        List<Student> result = studentService.SerchByName(hoTen);
        view.DisplayStudents(result);
    }

    private void UpdateStudent()
    {
        Console.Write("Nhập mã sinh viên cần cập nhật: ");
        string ma = Console.ReadLine() ?? "";
        Student? student= studentService.GetStudentById(ma);
        if(student == null)
        {
            Console.WriteLine("Sinh viên không tồn tại");
            return;
        }
        Console.WriteLine("\nNHẬP THÔNG TIN MỚI");
        string hoTen = InputRequired("Họ tên: ");
        DateTime ngaySinh = InputDate();
        string gioiTinh = InputRequired("Giới tính: ");
        string email = InputEmail();
        string soDienThoai = InputRequired("Số điện thoại: ");
        string nganhHoc = InputRequired("Ngành học: ");
        double diem = InputGPA();
        string trangThai = InputRequired("Trạng thái học tập: ");
        bool result = studentService.UpdateStudent(
            ma,
            hoTen,
            ngaySinh,
            gioiTinh,
            email,
            soDienThoai,
            nganhHoc,
            diem,
            trangThai);
        Console.WriteLine( result ?"Cập nhật thành công" :"Cập nhật không thành công");
    }

    private void DeleteStudent()
    {
        Console.WriteLine("Nhập mã sinh viên cần xóa: ");
        string ma= Console.ReadLine() ??"";
        bool result = studentService.DeleteStudent(ma);
        Console.WriteLine(
            result
                ? "Xóa sinh viên thành công."
                : "Sinh viên không tồn tại.");
    }
    private void SortByName()
    {
        view.DisplayStudents(
            studentService.SortByName());
    }

    private void SortByGPA()
    {
        view.DisplayStudents(
            studentService.SortByGPA());
    }

    private void DisplayGPAFrom8()
    {
        view.DisplayStudents(
            studentService.GetStudentsGPAFrom8());
    }

    private void DisplayHighestGPA()
    {
        view.DisplayStudents(
            studentService.GetHighestGPA());
    }
    private void DisplayAverageGPA()
    {
        double average =
            studentService.GetAverageGPA();

        Console.WriteLine($"Điểm trung bình toàn bộ: {average:F2}");
    }

    private void StatisticsByMajor()
    {
        Dictionary<string, int> result = studentService.StatisticsByMajor();
        Console.WriteLine("\nThống kê theo ngành");
        foreach(var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value} sinh viên");
        }
    }

    private void StatisticsByStatus()
    {
        Dictionary<string, int> result = studentService.StaticsticsByStatus();
        Console.WriteLine("\n Thống kê theo trạng thái");
        foreach(var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value} sinh viên");
        }
    }

    private string InputRequired(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine() ??"";
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Không được để trống");
        }
    }
    private DateTime InputDate()
    {
        while (true)
        {
            Console.Write("Ngày sinh (dd/MM/yyyy): ");
            string input = Console.ReadLine() ?? "";

            if (DateTime.TryParse(input, out DateTime date))
            {
                return date;
            }

            Console.WriteLine("Ngày không hợp lệ.");
        }
    }

    private string InputEmail()
    {
        while (true)
        {
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            if (StudentValidator.IsValidEmail(email))
            {
                return email.Trim();
            }

            Console.WriteLine("Email không đúng định dạng.");
        }
    }

    private double InputGPA()
    {
        while (true)
        {
            Console.Write("Điểm trung bình (0-10): ");
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out double gpa)
                && StudentValidator.IsValidDiem(gpa))
            {
                return gpa;
            }

            Console.WriteLine("Điểm phải từ 0 đến 10.");
        }
    }
}
