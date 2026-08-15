using System;
using System.Collections.Generic;
using System.Linq;
namespace Bai1_QuanLySinhVien;
public class StudentService
{
    private readonly List<Student> students = new();
    public bool AddStudent( Student student)
    {
        if(GetStudentById(student.MaSinhVien) != null)
        {
            return false;
        }
        students.Add(student);
        Student.InscreaseTotal();
        return true;
    }
    public List<Student> GetAlltudents()
    {
        return students;
    }

    public Student? GetStudentById(string maSinhVien)
    {
        return students.FirstOrDefault(
            s=> s.MaSinhVien.Equals( maSinhVien, StringComparison.OrdinalIgnoreCase));
    }

    public List<Student> SerchByName(string hoTen)
    {
        return students
            .Where(s=> s.HoTen.Contains(
                hoTen, StringComparison.OrdinalIgnoreCase))
            .ToList();

    }
    public bool UpdateStudent(
         string maSinhVien,
        string hoTen,
        DateTime ngaySinh,
        string gioiTinh,
        string email,
        string soDienThoai,
        string nganhHoc,
        double diemTrungBinh,
        string trangThaiHocTap)
    {
        Student? student = GetStudentById(maSinhVien);
        if(student == null)
        {
            return false;
        }
        student.HoTen = hoTen;
        student.NgaySinh = ngaySinh;
        student.GioiTinh = gioiTinh;
        student.Email = email;
        student.SoDienThoai = soDienThoai;
        student.NganhHoc = nganhHoc;
        student.DiemTrungBinh = diemTrungBinh;
        student.TrangThaiHocTap = trangThaiHocTap;
        return true;
    }

    public bool DeleteStudent(string maSinhVien)
    {
        Student? student = GetStudentById(maSinhVien);
        if(student == null)
        {
            return false;
        }
        students.Remove(student);
        Student.DecreaseTotal();
        return true;
    }

    public List<Student> SortByName()
    {
        return students
            .OrderBy(s => s.HoTen)
            .ToList();
    }
    public List<Student> SortByGPA()
    {
        return students
            .OrderByDescending(s => s.DiemTrungBinh)
            .ToList();
    }
    public List<Student> GetStudentsGPAFrom8()
    {
        return students
            .Where(s => s.DiemTrungBinh>=8)
            .ToList();
    }
    public List<Student> GetHighestGPA()
    {
        if(students.Count == 0)
        {
            return new List<Student>();
        }
        double maxGPA = students.Max(s => s.DiemTrungBinh);
        return students
            .Where(s => s.DiemTrungBinh == maxGPA)
            .ToList();
    }
    
    public double GetAverageGPA()
    {
        if(students.Count == 0)
        {
            return 0;
        }
        return students.Average(s => s.DiemTrungBinh);
    }

    public Dictionary<string, int> StatisticsByMajor()
    {
        return students
            .GroupBy(s => s.NganhHoc)
            .ToDictionary(
                group => group.Key,
                group => group.Count());
    }

    public Dictionary<string, int> StaticsticsByStatus()
    {
        return students
            .GroupBy(s => s.TrangThaiHocTap)
            .ToDictionary(
                group => group.Key,
                group => group.Count());
    }

}