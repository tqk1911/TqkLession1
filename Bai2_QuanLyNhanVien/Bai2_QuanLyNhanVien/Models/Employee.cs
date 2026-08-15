using System;
namespace Bai2_QuanLyNhanVien.Models;

public abstract class Employee
{
    public string MaNhanVien {get; set;}
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public DateTime NgayVaoLam { get; set; }
    public decimal LuongCoBan { get; set; }

    public Employee(
        string maNhanVien,
        string hoTen,
        string phongBan,
        DateTime ngayVaoLam,
        decimal luongCoBan)
    {
        MaNhanVien = maNhanVien;
        HoTen = hoTen;
        PhongBan = phongBan;
        NgayVaoLam = ngayVaoLam;
        LuongCoBan = luongCoBan;
    }
    public abstract decimal CaculateSalary();
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Mã nhân viên: {MaNhanVien}");
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Phòng ban: {PhongBan}");
        Console.WriteLine($"Ngày vào làm: {NgayVaoLam:dd/MM/yyyy}");
        Console.WriteLine($"Lương cơ bản: {LuongCoBan:N0}");
    }
}