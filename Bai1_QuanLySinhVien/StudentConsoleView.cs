using System;
using System.Collections.Generic;
using System.Linq;
namespace Bai1_QuanLySinhVien;
public class StudentConsoleView
{
    public Student InputStudent()
    {
        Console.WriteLine("\nThêm Sinh Viên\n");
        string maSinhVien = InputMaSinhVien();
        string hoTen = InputHoTen();
        DateTime ngaySinh = InputNgaySinh();
        string gioiTinh = InputString("Giới tính: ");
        string email = InputEmail();
        string soDienThoai = InputString("Số điện thoại: ");
        string nganhHoc = InputString("Ngành học: ");
        double diemTrungBinh = InputDiem();
        string trangThai = InputString("Trạng thái học tập: ");
        return new Student(
            maSinhVien,
            hoTen,
            ngaySinh,
            gioiTinh,
            email,
            soDienThoai,
            nganhHoc,
            diemTrungBinh,
            trangThai);
    }
    private string InputMaSinhVien()
    {
        while(true){
            Console.WriteLine("Mã sinh viên: ");
            string input = Console.ReadLine() ??"";
            if (StudentValidator.IsValidMaSinhVien(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Không được để trống");
        }
    }

    private string InputHoTen()
    {
        while(true){
            Console.WriteLine("Họ tên: ");
            string input = Console.ReadLine() ??"";
            if (StudentValidator.IsValidMaSinhVien(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Không được để trống");
        }
    }

    private DateTime InputNgaySinh()
    {
        while(true){
            Console.WriteLine("Ngày sinh (dd/MM/yyyy): ");
            string input = Console.ReadLine() ??"";
            if(DateTime.TryParse(input, out DateTime ngaySinh))
            {
                return ngaySinh;
            }
            Console.WriteLine("Ngày sinh không hợp lệ");
        }
    }

    private string InputEmail()
    {
        while(true){
            Console.WriteLine("Email: ");
            string input = Console.ReadLine() ??"";
            if (StudentValidator.IsValidEmail(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Không được để trống");
        }
    }

    private double InputDiem()
    {
        while(true){
            Console.WriteLine("Điểm: ");
            string input = Console.ReadLine() ??"";
            if(double.TryParse(input, out double diem))
            {
                return diem;
            }
            Console.WriteLine("Điểm không hợp lệ");
        }
    }

    private string InputString(string message)
    {
        while(true){
            Console.WriteLine(message);
            string input = Console.ReadLine() ??"";
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Không được để trống");
        }
    }

    public void DisplayStudents(Student student)
    {
        Console.WriteLine(student);
    }
    public void DisplayStudents(IEnumerable<Student> students)
    {
        List<Student> list = students.ToList();
        if (list.Count == 0)
        {
            Console.WriteLine("Không có sinh viên");
            return;
        }
        Console.WriteLine("\nDANH SÁCH SINH VIÊN");
        foreach( Student student in list)
        {
            DisplayStudents(student);
        }
    }
}